# POS — Point of Sale

Aplikasi **Point of Sale (kasir)** untuk toko/retail, dibangun dengan **.NET 10** dan
arsitektur **Clean Architecture**. Data disimpan secara lokal menggunakan **SQLite**
dengan akses data ringan lewat **Dapper**. Antarmuka pengguna menggunakan **Windows Forms**,
dengan *dependency injection* (`Microsoft.Extensions.DependencyInjection`) sebagai perekat antar-layer.

> 🚧 **Status: Dalam pengembangan aktif.**
> Backend transaksi **Pembelian**, **Penjualan**, **Stock Opname**, dan **Kartu Stok (Stock Ledger)**
> sudah berjalan penuh (moving average HPP, pembayaran cicilan/hutang supplier, snapshot COGS,
> pencatatan tiap pergerakan stok) dan telah diverifikasi lewat `POS.Playground`.
> Aplikasi dimulai dengan **Login** dan menerapkan **hak akses berbasis peran**
> (Manajer, Stocker, Kasir). UI WinForms tersedia untuk master data (Produk, Kategori,
> Supplier, Pelanggan), **Kasir**, **Pembelian**, **Pembayaran Hutang**, **Stock Opname**,
> **Kartu Stok**, **Manajemen User**, dan **Laporan** (penjualan/laba kotor, pembelian,
> hutang supplier, nilai persediaan).
> Modul Dashboard masih dalam pengerjaan.

---

## Arsitektur

Solusi ini dipecah menjadi beberapa project sesuai lapisan Clean Architecture:

| Project | Peran | Ketergantungan |
| --- | --- | --- |
| **POS.Domain** | Entity, interface repository, aturan bisnis inti (moving average, validasi stok, status pembayaran, penyesuaian opname, peran user). Tidak bergantung pada layer lain. | — |
| **POS.Application** | Service / use case: Produk, Kategori, Supplier, Pelanggan, Pembelian, Penjualan, Stock Opname, Stock Ledger, User, Laporan. Berisi interface service, request DTO, dan hashing password (PBKDF2). | Domain |
| **POS.Infrastructure** | Implementasi akses data: SQLite, Dapper, migration, repository. Rencana: Backup, Export, Printing. | Domain |
| **POS.WinForms** | Antarmuka pengguna (Windows Forms) + komposisi DI. Entry point aplikasi. | Application, Infrastructure |
| **POS.Playground** | Console harness untuk **verifikasi backend transaksi** (Beli, Jual, Ledger, Opname) secara deterministik. | Application, Infrastructure |

Arah ketergantungan mengarah ke dalam menuju `POS.Domain`, sehingga aturan bisnis tetap
independen dari database maupun UI.

---

## Teknologi

- **.NET 10** (`net10.0`, dan `net10.0-windows` untuk WinForms)
- **C#** dengan `ImplicitUsings` dan `Nullable` diaktifkan
- **SQLite** (`Microsoft.Data.Sqlite`, `SQLitePCLRaw.bundle_e_sqlite3`)
- **Dapper** — micro-ORM untuk pemetaan query ke object
- **Microsoft.Extensions.DependencyInjection** — DI container
- **Windows Forms** — antarmuka desktop

---

## Fitur yang sudah ada

### Autentikasi & hak akses (`UserService`)
- **Login** wajib sebelum masuk menu utama; password disimpan sebagai hash **PBKDF2-SHA256**
  (`PasswordHasher`, format `iterations.salt.hash`, verifikasi *fixed-time*)
- **Tiga peran**: `Manajer`, `Stocker`, `Kasir` — menu utama menyesuaikan diri:
  - Master data terlihat semua peran, tetapi **mode lihat saja** untuk non-Manajer (`IReadOnlyForm`)
  - Kasir/Penjualan: Manajer & Kasir · Pembelian/Hutang/Stok: Manajer & Stocker · Manajemen User: Manajer
- **Manajemen user** (CRUD, ubah role, ganti password) dengan proteksi *tidak bisa menghapus/menurunkan Manajer terakhir*
- Seed akun **Manajer default** (`admin` / `admin`) otomatis dibuat bila belum ada user

### Master data
- **Entity domain**: `Product`, `Category`, `Supplier`, `Customer`
- **Repository** (interface di Domain, implementasi di Infrastructure): CRUD + pencarian
  barcode/nama untuk `Product`, serta `Category`, `Supplier`, `Customer`
- **Form CRUD WinForms**: Produk, Kategori, Supplier, Pelanggan (`MainForm` sebagai menu utama)

### Transaksi Pembelian (`PurchaseService`)
- Terima stok dengan **konversi satuan beli → satuan jual** (`ConversionFactor`)
- **Moving average cost** (HPP berjalan) dihitung di entity `Product.ReceiveStock`
- Pembayaran **cicilan/hutang**: status `Lunas` / `Sebagian` / `Belum Lunas`,
  histori pembayaran (`purchase_payments`), dan perhitungan **hutang supplier**
- Form **Pembelian** dan **Pembayaran Hutang** di WinForms

### Transaksi Penjualan / Kasir (`SalesService`)
- Pengurangan stok dengan validasi (`Product.ReduceStock`)
- **Snapshot COGS** (`cost_of_goods_sold`) memakai `average_cost` saat transaksi
- Aturan bisnis: penjualan **harus lunas** (`EnsurePaidInFull`)
- Form **Kasir** di WinForms

### Stok
- **Kartu Stok / Stock Ledger** (`StockLedgerService`): setiap pergerakan (Pembelian, Penjualan,
  Opname) tercatat dengan `quantity_change`, `stock_before`, `stock_after`, referensi dokumen,
  dan bisa ditelusuri per produk maupun rentang tanggal
- **Stock Opname** (`StockOpnameService`): penyesuaian stok ke hasil hitung fisik,
  menyimpan selisih per produk dan otomatis mencatat ledger
- Form **Stock Opname** dan **Kartu Stok** di WinForms

### Laporan (`ReportService`)
- **Penjualan & Laba Kotor** per rentang tanggal: jumlah transaksi, omzet, HPP, laba kotor,
  serta rincian per produk
- **Pembelian per Supplier** per rentang tanggal: total pembelian, terbayar, dan sisa
- **Hutang Supplier** berjalan
- **Nilai Persediaan** (stok × average cost)
- Form **Laporan** di WinForms dengan tab yang **menyesuaikan peran** user (mis. Hutang hanya Manajer)

### Persistensi
- **Skema database** (`Migration`): `category`, `suppliers`, `customers`, `products`,
  `purchase_header`, `purchase_detail`, `purchase_payments`, `sales_header`, `sales_detail`,
  `stock_ledger`, `stock_opname_header`, `stock_opname_detail`, `users`, beserta index terkait
- **Migrasi kolom aman** untuk DB lama (`EnsureColumn`, mis. penambahan `average_cost`)
- **Connection factory** SQLite dengan `PRAGMA foreign_keys = ON`

## Rencana / belum dikerjakan

- Modul UI WinForms: Dashboard
- Fitur Infrastructure: Backup, Export, Printing (folder sudah disiapkan)

---

## Struktur folder

```
POS/
├─ POS.slnx                     # Solution
├─ POS.Domain/
│  ├─ Entities/                 # Product, Category, Supplier, Customer,
│  │                            #   Purchase*, Sales*, StockLedgerEntry, StockOpname*,
│  │                            #   UserAccount, UserRole,
│  │                            #   PaymentStatus, MovementType/ReferenceType
│  ├─ Reports/                  # ReportRows (read-model laporan)
│  ├─ Interfaces/               # I{Product,Category,Supplier,Customer,Purchase,Sales,
│  │                            #   StockLedger,StockOpname,User,Report}Repository
│  └─ Exceptions/               # Validation, EntityNotFound, DuplicateEntity
├─ POS.Application/
│  ├─ Interfaces/               # I{...}Service untuk tiap use case
│  ├─ Requests/                 # PurchaseItemRequest, SaleItemRequest, OpnameLineRequest
│  ├─ Security/                 # PasswordHasher (PBKDF2-SHA256)
│  └─ Services/                 # implementasi service
├─ POS.Infrastructure/
│  ├─ Data/                     # SqliteConnectionFactory.cs, Migration.cs
│  ├─ Repositories/             # Product, Category, Supplier, Customer, Purchase,
│  │                            #   Sales, StockLedger, StockOpname, User, Report
│  ├─ Backup/  Export/  Printing/
├─ POS.WinForms/
│  ├─ Program.cs                # Entry point + DI + migration + seed admin + login
│  ├─ Data/                     # ServiceCollectionExtensions, UserSession, IReadOnlyForm
│  ├─ Forms/
│  │  ├─ MainForm               # menu utama (menyesuaikan peran)
│  │  ├─ Login/                 # LoginForm, UserForm
│  │  ├─ Products/              # Product, Category, Supplier, Customer (+ .ReadOnly)
│  │  ├─ Cashier/               # KasirForm
│  │  ├─ Purchasing/            # PembelianForm, PembayaranHutangForm
│  │  ├─ Stock/                 # StockOpnameForm, StockLedgerForm
│  │  └─ Reports/               # LaporanForm
│  └─ Components/
└─ POS.Playground/
   └─ Program.cs                # Verifikasi backend (Beli, Jual, Ledger, Opname)
```

---

## Cara menjalankan

Prasyarat: **.NET 10 SDK** terpasang.

Pulihkan dependency dan build:

```bash
dotnet restore
dotnet build
```

### Verifikasi backend transaksi (console)

`POS.Playground` menjalankan serangkaian skenario assert terhadap alur Pembelian, Penjualan,
Kartu Stok, dan Stock Opname: seed produk (1 DUS = 40 PCS), pembelian dengan moving average,
pembayaran cicilan hingga lunas, hutang supplier, penjualan dengan snapshot COGS, penolakan
kurang bayar dan stok kurang, pencatatan ledger tiap pergerakan, serta penyesuaian stok via opname.
Database sementara `pos_verify.db` dibuat dan dihapus otomatis agar `pos.db` tidak terkotori.
Proses keluar dengan kode `0` bila semua PASS.

```bash
dotnet run --project POS.Playground
```

### Menjalankan aplikasi desktop (WinForms)

> Hanya berjalan di Windows. Aplikasi dibuka dengan layar **Login**, lalu menu utama
> menyesuaikan diri dengan peran user: master data (Produk, Kategori, Supplier, Pelanggan),
> Kasir, Pembelian, Pembayaran Hutang, Stock Opname, Kartu Stok, Manajemen User, dan Laporan.
>
> Saat pertama kali dijalankan, akun **Manajer default** dibuat otomatis:
> username `admin`, password `admin` — ganti password ini setelah login.

```bash
dotnet run --project POS.WinForms
```

---

## Database

Skema dibuat otomatis lewat `Migration.Run()` saat aplikasi mulai (dipanggil di `Program.cs`).
File database SQLite (`pos.db`) bersifat lokal dan **tidak** ikut di-commit
(sudah dikecualikan melalui `.gitignore`).
