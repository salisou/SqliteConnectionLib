using System.Data.SQLite;

namespace SqliteConnectionLib;

/// <summary>
/// Classe che fornisce servizi per la connessione e l'esecuzione di query su un database SQLite.
/// </summary>
public class SqliteService
{
	// Stringa di connessione per il database SQLite
	private string _connectionString;

	/// <summary>
	/// Inizializza una nuova istanza della classe SqliteService con il percorso specificato per il database SQLite.
	/// </summary>
	/// <param name="databasePath">Il percorso al file del database SQLite.</param>
	public SqliteService(string databasePath)
	{
		_connectionString = $"Data Source={databasePath};Version=3;";
	}

	/// <summary>
	/// Apre una connessione al database SQLite e la restituisce.
	/// </summary>
	/// <returns>Un'istanza di <see cref="SQLiteConnection"/> aperta.</returns>
	public SQLiteConnection OpenConnection()
	{
		var connection = new SQLiteConnection(_connectionString);
		connection.Open();
		return connection;
	}

	/// <summary>
	/// Esegue una query SQL sul database SQLite.
	/// </summary>
	/// <param name="query">La query SQL da eseguire.</param>
	/// <remarks>
	/// Questo metodo apre una connessione al database, esegue la query e chiude la connessione automaticamente.
	/// La query è eseguita usando il metodo <see cref="SQLiteCommand.ExecuteNonQuery"/>.
	/// </remarks>
	public void ExecuteQuery(string query)
	{
		using (var connection = OpenConnection())
		{
			using (var command = new SQLiteCommand(query, connection))
			{
				command.ExecuteNonQuery();
			}
		}
	}

	/// <summary>
	/// Chiude la connessione al database SQLite se è aperta.
	/// </summary>
	/// <param name="connection">L'istanza della connessione SQLite da chiudere.</param>
	/// <remarks>
	/// Questo metodo verifica che la connessione non sia null e che sia aperta prima di chiuderla.
	/// </remarks>
	public void CloseConnection(SQLiteConnection connection)
	{
		if (connection != null && connection.State == System.Data.ConnectionState.Open)
		{
			connection.Close();
		}
	}
}
