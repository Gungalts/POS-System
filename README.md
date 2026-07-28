# POS — Point of Sale

Aplikasi **Point of Sale (kasir)** untuk toko/retail, dibangun dengan **.NET 10** dan
arsitektur **Clean Architecture**. Data disimpan secara lokal menggunakan **SQLite**
dengan akses data ringan lewat **Dapper**. Antarmuka pengguna menggunakan **Windows Forms**,
dengan *dependency injection* (`Microsoft.Extensions.DependencyInjection`) sebagai perekat antar-layer.

> 🚧 **Status: Dalam pengembangan aktif.**
> Backend transaksi **Pembelian** dan **Penjualan** sudah berjalan penuh (moving average HPP,
> pembayaran cicilan/hutang supplier, snapshot COGS) dan telah diverifikasi lewat `POS.Playground`.
> Master data **Kategori, Supplier, dan Pelanggan** sudah punya form CRUD di WinForms.
> Modul UI untuk Produk, Kasir, Pembelian, dan Laporan masih dalam pengerjaan.

---

## Arsitektur

Solusi ini dipecah menjadi beberapa project sesuai lapisan Clean Architecture:

| Project | Peran | Ketergantungan |
| --- | --- | --- |
| **POS.Domain** | Entity, interface repository, aturan bisnis inti (moving average, validasi stok, status pembayaran). Tidak bergantung pada layer lain. | — |
| **POS.Application** | Service / use case: Kategori, Supplier, Pelanggan, Pembelian, Penjualan. Berisi interface service dan request DTO. | Domain |
| **POS.Infrastructure** | Implementasi akses data: SQLite, Dapper, migration, repository. Rencana: Backup, Export, Printing. | Domain |
| **POS.WinForms** | Antarmuka pengguna (Windows Forms) + komposisi DI. Entry point aplikasi. | Application, Infrastructure |
| **POS.Playground** | Console harness untuk **verifikasi backend transaksi** (Beli & Jual) secara deterministik. | Application, Infrastructure |

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

### Master data
- **Entity domain**: `Product`, `Category`, `Supplier`, `Customer`
- **Repository** (interface di Domain, implementasi di Infrastructure): CRUD + pencarian
  barcode/nama untuk `Product`, serta `Category`, `Supplier`, `Customer`
- **Form CRUD WinForms**: Kategori, Supplier, Pelanggan (`MainForm` sebagai menu utama)

### Transaksi Pembelian (`PurchaseService`)
- Terima stok dengan **konversi satuan beli → satuan jual** (`ConversionFactor`)
- **Moving average cost** (HPP berjalan) dihitung di entity `Product.ReceiveStock`
- Pembayaran **cicilan/hutang**: status `Lunas` / `Sebagian` / `Belum Lunas`,
  histori pembayaran (`purchase_payments`), dan perhitungan **hutang supplier**

### Transaksi Penjualan (`SalesService`)
- Pengurangan stok dengan validasi (`Product.ReduceStock`)
- **Snapshot COGS** (`cost_of_goods_sold`) memakai `average_cost` saat transaksi
- Aturan bisnis: penjualan **harus lunas** (`EnsurePaidInFull`)

### Persistensi
- **Skema database** (`Migration`): `category`, `suppliers`, `customers`, `products`,
  `purchase_header`, `purchase_detail`, `purchase_payments`, `sales_header`, `sales_detail`,
  beserta index terkait
- **Migrasi kolom aman** untuk DB lama (`EnsureColumn`, mis. penambahan `average_cost`)
- **Connection factory** SQLite dengan `PRAGMA foreign_keys = ON`

## Rencana / belum dikerjakan

- Modul UI WinForms: Login, Dashboard, Kasir, Produk, Pembelian, Laporan (folder sudah disiapkan)
- Fitur Infrastructure: Backup, Export, Printing (folder sudah disiapkan)
- Laporan (penjualan, pembelian, laba/rugi, hutang)

---

## Struktur folder

```
POS/
├─ POS.slnx                     # Solution
├─ POS.Domain/
│  ├─ Entities/                 # Product, Category, Supplier, Customer,
│  │                            #   PurchaseHeader/Detail/Payment, SalesHeader/Detail, PaymentStatus
│  ├─ Interfaces/               # I{Product,Category,Supplier,Customer,Purchase,Sales}Repository
│  └─ Exceptions/               # Validation, EntityNotFound, DuplicateEntity
├─ POS.Application/
│  ├─ Interfaces/               # I{Category,Supplier,Customer,Purchase,Sales}Service
│  ├─ Requests/                 # PurchaseItemRequest, SaleItemRequest
│  └─ Services/                 # implementasi service
├─ POS.Infrastructure/
│  ├─ Data/                     # SqliteConnectionFactory.cs, Migration.cs
│  ├─ Repositories/             # Product, Category, Supplier, Customer, Purchase, Sales
│  ├─ Backup/  Export/  Printing/
├─ POS.WinForms/
│  ├─ Program.cs                # Entry point + komposisi DI + migration
│  ├─ Data/                     # ServiceCollectionExtensions (AddPosServices)
│  ├─ Forms/                    # MainForm; Products/ (Category, Supplier, Customer)
│  └─ Components/
└─ POS.Playground/
   └─ Program.cs                # Verifikasi backend transaksi (Beli & Jual)
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

`POS.Playground` menjalankan serangkaian skenario assert terhadap alur Pembelian & Penjualan:
seed produk (1 DUS = 40 PCS), pembelian dengan moving average, pembayaran cicilan hingga lunas,
hutang supplier, penjualan dengan snapshot COGS, serta penolakan kurang bayar dan stok kurang.
Database sementara `pos_verify.db` dibuat dan dihapus otomatis agar `pos.db` tidak terkotori.
Proses keluar dengan kode `0` bila semua PASS.

```bash
dotnet run --project POS.Playground
```

### Menjalankan aplikasi desktop (WinForms)

> Hanya berjalan di Windows. Saat ini menyediakan menu utama dan form CRUD
> Kategori, Supplier, dan Pelanggan.

```bash
dotnet run --project POS.WinForms
```

---

## Database

Skema dibuat otomatis lewat `Migration.Run()` saat aplikasi mulai (dipanggil di `Program.cs`).
File database SQLite (`pos.db`) bersifat lokal dan **tidak** ikut di-commit
(sudah dikecualikan melalui `.gitignore`).
