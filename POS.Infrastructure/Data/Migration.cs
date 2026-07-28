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
			");
	}
}
