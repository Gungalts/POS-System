using System.Data;
using Microsoft.Data.Sqlite;

namespace POS.Infrastructure.Data;

public interface IDbConnectionFactory
{
	IDbConnection CreateConnection();
}

public class SqliteConnectionFactory : IDbConnectionFactory
{
	private readonly string _connectionString;

	public SqliteConnectionFactory(string connectionString)
		=> _connectionString = connectionString;

	public IDbConnection CreateConnection()
	{
		var conn = new SqliteConnection(_connectionString);
		conn.Open();
		using var cmd = conn.CreateCommand();
		cmd.CommandText = "PRAGMA foreign_keys = ON;";
		cmd.ExecuteNonQuery();
		return conn;
	}
}
