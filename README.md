# POS — Point of Sale

Aplikasi **Point of Sale (kasir)** untuk toko/retail, dibangun dengan **.NET 10** dan
arsitektur **Clean Architecture**. Data disimpan secara lokal menggunakan **SQLite**
dengan akses data ringan lewat **Dapper**. Antarmuka pengguna menggunakan **Windows Forms**.

> ⚠️ **Status: Dalam pengembangan awal (early stage).**
> Fondasi arsitektur, layer domain, dan akses data untuk **Produk, Kategori, Supplier, dan Pelanggan** sudah berjalan.
> Antarmuka WinForms dan modul transaksi (Kasir, Pembelian, Laporan, dsb.) masih berupa kerangka.

---

## Arsitektur

Solusi ini dipecah menjadi beberapa project sesuai lapisan Clean Architecture:

| Project | Peran | Ketergantungan |
| --- | --- | --- |
| **POS.Domain** | Entity, interface repository, dan aturan bisnis inti. Tidak bergantung pada layer lain. | — |
| **POS.Application** | Service / use case aplikasi (masih kosong, disiapkan). | Domain |
| **POS.Infrastructure** | Implementasi akses data: SQLite, Dapper, migration, repository. Rencana: Backup, Export, Printing. | Domain |
| **POS.WinForms** | Antarmuka pengguna (Windows Forms). Entry point aplikasi. | Application, Infrastructure |
| **POS.Playground** | Aplikasi console untuk mencoba/mendemokan alur data tanpa UI. | Infrastructure |

Arah ketergantungan mengarah ke dalam menuju `POS.Domain`, sehingga aturan bisnis tetap
independen dari database maupun UI.

---

## Teknologi

- **.NET 10** (`net10.0`, dan `net10.0-windows` untuk WinForms)
- **C#** dengan `ImplicitUsings` dan `Nullable` diaktifkan
- **SQLite** (`Microsoft.Data.Sqlite`, `SQLitePCLRaw.bundle_e_sqlite3`)
- **Dapper** — micro-ORM untuk pemetaan query ke object
- **Windows Forms** — antarmuka desktop

---

## Fitur yang sudah ada

- **Entity domain**: `Product`, `Category`, `Supplier`, `Customer`
- **Aturan bisnis pada `Product`**:
  - `IsStockSufficient(qty)` — cek kecukupan stok
  - `ReduceStock(qty)` — pengurangan stok dengan validasi
  - `ConvertPurchaseToSaleUnit(qty)` — konversi satuan beli → satuan jual
- **Skema database** (`Migration`): tabel `category`, `suppliers`, `customers`, `products`, beserta index barcode, nama produk, nama pelanggan, dan nama supplier
- **Repository** dengan interface di layer Domain: `ProductRepository` (CRUD + pencarian barcode/nama), `CategoryRepository`, `SupplierRepository`, `CustomerRepository`
- **Connection factory** SQLite dengan `PRAGMA foreign_keys = ON`

## Rencana / belum dikerjakan

- Modul UI WinForms: Login, Dashboard, Kasir, Produk, Pembelian, Laporan (folder sudah disiapkan, masih kosong)
- Layer `POS.Application` (service / use case)
- Fitur Infrastructure: Backup, Export, Printing (folder sudah disiapkan)
- Entity & repository untuk transaksi penjualan/pembelian

---

## Struktur folder

```
POS/
├─ POS.slnx                     # Solution
├─ POS.Domain/
│  ├─ Entities/                 # Product, Category, Supplier, Customer
│  ├─ Interfaces/               # I{Product,Category,Supplier,Customer}Repository
│  └─ Exceptions/
├─ POS.Application/
│  └─ Services/
├─ POS.Infrastructure/
│  ├─ Data/                     # SqliteConnectionFactory.cs, Migration.cs
│  ├─ Repositories/             # Product, Category, Supplier, Customer repository
│  ├─ Backup/  Export/  Printing/
├─ POS.WinForms/
│  ├─ Program.cs                # Entry point
│  ├─ Forms/ (Login, Dashboard, Cashier, Products, Purchasing, Reports)
│  ├─ Components/  Data/
└─ POS.Playground/
   └─ Program.cs                # Demo alur data via console
```

---

## Cara menjalankan

Prasyarat: **.NET 10 SDK** terpasang.

Pulihkan dependency dan build:

```bash
dotnet restore
dotnet build
```

### Mencoba alur data (console)

`POS.Playground` mendemokan migration + operasi repository: menambah produk,
mencari via barcode, mengurangi stok, serta menambah kategori, supplier, dan
pelanggan. Database `pos.db` akan dibuat otomatis di folder kerja.

```bash
dotnet run --project POS.Playground
```

### Menjalankan aplikasi desktop (WinForms)

> Hanya berjalan di Windows. Saat ini masih menampilkan form kosong.

```bash
dotnet run --project POS.WinForms
```

---

## Database

Skema dibuat otomatis lewat `Migration.Run()` saat pertama kali koneksi digunakan.
File database SQLite (`pos.db`) bersifat lokal dan **tidak** ikut di-commit
(sudah dikecualikan melalui `.gitignore`).
