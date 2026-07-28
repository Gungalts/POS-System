using System.Data;
using Dapper;

namespace POS.Infrastructure.Data;

public class Migration
{
	private readonly IDbConnectionFactory _factory;
	public Migration(IDbConnectionFactory factory) => _factory = factory;

	public void Run()
	{
		using var conn = _factory.CreateConnection();

		conn.Execute(@"
			CREATE TABLE IF NOT EXISTS category (
				category_id INTEGER PRIMARY KEY AUTOINCREMENT,
				category_name TEXT NOT NULL UNIQUE,
				created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
				updated_at DATETIME DEFAULT CURRENT_TIMESTAMP
			);

			CREATE TABLE IF NOT EXISTS suppliers (
				supplier_id INTEGER PRIMARY KEY AUTOINCREMENT,
				supplier_name TEXT NOT NULL,
				phone_number TEXT,
				created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
				updated_at DATETIME DEFAULT CURRENT_TIMESTAMP
			);

			CREATE TABLE IF NOT EXISTS customers (
				customer_id INTEGER PRIMARY KEY AUTOINCREMENT,
				customer_name TEXT NOT NULL,
				phone_number TEXT,
				address TEXT,
				created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
				updated_at DATETIME DEFAULT CURRENT_TIMESTAMP
			);

			CREATE TABLE IF NOT EXISTS products (
				product_id INTEGER PRIMARY KEY AUTOINCREMENT,
				barcode TEXT NOT NULL UNIQUE,
				product_name TEXT NOT NULL,
				category_id INTEGER,
				supplier_id INTEGER,
				sale_unit TEXT NOT NULL,
				purchase_unit TEXT NOT NULL,
				conversion_factor INTEGER NOT NULL DEFAULT 1,
				sale_price INTEGER NOT NULL,
				purchase_price INTEGER NOT NULL,
				stock INTEGER NOT NULL DEFAULT 0,
				created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
				updated_at DATETIME DEFAULT CURRENT_TIMESTAMP,
				FOREIGN KEY (category_id) REFERENCES category(category_id),
				FOREIGN KEY (supplier_id) REFERENCES suppliers(supplier_id)
			);
			
			CREATE INDEX IF NOT EXISTS idx_products_barcode ON products(barcode);
			CREATE INDEX IF NOT EXISTS idx_products_name ON products(product_name);
			CREATE INDEX IF NOT EXISTS idx_customers_name ON customers(customer_name);
			CREATE INDEX IF NOT EXISTS idx_suppliers_name ON suppliers(supplier_name);

			CREATE TABLE IF NOT EXISTS purchase_header (
				purchase_id INTEGER PRIMARY KEY AUTOINCREMENT,
				supplier_id INTEGER NOT NULL,
				purchase_date DATETIME DEFAULT CURRENT_TIMESTAMP,
				grand_total INTEGER NOT NULL,
				payment_status TEXT NOT NULL DEFAULT 'Belum Lunas',
				amount_paid INTEGER NOT NULL DEFAULT 0,
				notes TEXT,
				created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
				updated_at DATETIME DEFAULT CURRENT_TIMESTAMP,
				FOREIGN KEY (supplier_id) REFERENCES suppliers(supplier_id)
			);

			CREATE TABLE IF NOT EXISTS purchase_detail (
				purchase_detail_id INTEGER PRIMARY KEY AUTOINCREMENT,
				purchase_id INTEGER NOT NULL,
				product_id INTEGER NOT NULL,
				quantity INTEGER NOT NULL,
				purchase_price INTEGER NOT NULL,
				subtotal INTEGER NOT NULL,
				FOREIGN KEY (purchase_id) REFERENCES purchase_header(purchase_id),
				FOREIGN KEY (product_id) REFERENCES products(product_id)
			);

			CREATE TABLE IF NOT EXISTS purchase_payments (
				payment_id INTEGER PRIMARY KEY AUTOINCREMENT,
				purchase_id INTEGER NOT NULL,
				amount INTEGER NOT NULL,
				payment_date DATETIME DEFAULT CURRENT_TIMESTAMP,
				notes TEXT,
				created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
				FOREIGN KEY (purchase_id) REFERENCES purchase_header(purchase_id)
			);

			CREATE TABLE IF NOT EXISTS sales_header (
				sale_id INTEGER PRIMARY KEY AUTOINCREMENT,
				customer_id INTEGER,
				sale_date DATETIME DEFAULT CURRENT_TIMESTAMP,
				grand_total INTEGER NOT NULL,
				payment_method TEXT,
				amount_paid INTEGER NOT NULL,
				created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
				FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
			);

			CREATE TABLE IF NOT EXISTS sales_detail (
				sale_detail_id INTEGER PRIMARY KEY AUTOINCREMENT,
				sale_id INTEGER NOT NULL,
				product_id INTEGER NOT NULL,
				quantity INTEGER NOT NULL,
				sale_price INTEGER NOT NULL,
				cost_of_goods_sold REAL NOT NULL,
				subtotal INTEGER NOT NULL,
				FOREIGN KEY (sale_id) REFERENCES sales_header(sale_id),
				FOREIGN KEY (product_id) REFERENCES products(product_id)
			);

			CREATE INDEX IF NOT EXISTS idx_purchase_supplier ON purchase_header(supplier_id);
			CREATE INDEX IF NOT EXISTS idx_purchase_payments_purchase ON purchase_payments(purchase_id);
			CREATE INDEX IF NOT EXISTS idx_sales_customer ON sales_header(customer_id);
			CREATE INDEX IF NOT EXISTS idx_sales_date ON sales_header(sale_date);

			CREATE TABLE IF NOT EXISTS stock_ledger (
				ledger_id INTEGER PRIMARY KEY AUTOINCREMENT,
				product_id INTEGER NOT NULL,
				movement_type TEXT NOT NULL,
				quantity_change INTEGER NOT NULL,
				stock_before INTEGER NOT NULL,
				stock_after INTEGER NOT NULL,
				reference_type TEXT,
				reference_id INTEGER,
				notes TEXT,
				created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
				FOREIGN KEY (product_id) REFERENCES products(product_id)
			);

			CREATE TABLE IF NOT EXISTS stock_opname_header (
				opname_id INTEGER PRIMARY KEY AUTOINCREMENT,
				opname_date DATETIME DEFAULT CURRENT_TIMESTAMP,
				notes TEXT,
				created_at DATETIME DEFAULT CURRENT_TIMESTAMP
			);

			CREATE TABLE IF NOT EXISTS stock_opname_detail (
				opname_detail_id INTEGER PRIMARY KEY AUTOINCREMENT,
				opname_id INTEGER NOT NULL,
				product_id INTEGER NOT NULL,
				system_stock INTEGER NOT NULL,
				physical_stock INTEGER NOT NULL,
				difference INTEGER NOT NULL,
				FOREIGN KEY (opname_id) REFERENCES stock_opname_header(opname_id),
				FOREIGN KEY (product_id) REFERENCES products(product_id)
			);

			CREATE INDEX IF NOT EXISTS idx_stock_ledger_product ON stock_ledger(product_id);
			CREATE INDEX IF NOT EXISTS idx_stock_ledger_created ON stock_ledger(created_at);
			CREATE INDEX IF NOT EXISTS idx_opname_detail_opname ON stock_opname_detail(opname_id);
			");

		EnsureColumn(conn, "products", "average_cost", "REAL NOT NULL DEFAULT 0");
	}

	// Menambah kolom bila belum ada — untuk DB lama yang tabelnya sudah terlanjur dibuat
	// (CREATE TABLE IF NOT EXISTS tidak akan menambah kolom baru pada tabel eksisting).
	private static void EnsureColumn(IDbConnection conn, string table, string column, string definition)
	{
		var existing = conn.Query<string>($"SELECT name FROM pragma_table_info('{table}');");
		if (!existing.Any(c => string.Equals(c, column, StringComparison.OrdinalIgnoreCase)))
			conn.Execute($"ALTER TABLE {table} ADD COLUMN {column} {definition};");
	}
}
