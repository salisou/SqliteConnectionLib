using Microsoft.Maui.Storage;
using SQLite;

namespace SqliteConnectionLib
{
	public static class Constants
	{
		// Nome del file di database SQLite
		private const string DbFileName = "Sqlie.db3";

		// Flag per gestire le impostazioni della connessione SQLite
		public const SQLiteOpenFlags flags =
			SQLiteOpenFlags.ReadWrite |   // Permette la lettura e scrittura del database
			SQLiteOpenFlags.Create |      // Crea il database se non esiste
			SQLiteOpenFlags.SharedCache;  // Permette la condivisione della cache tra connessioni

		// Percorso del database
		public static string DatabasePath
		{
			// Restituisce il percorso completo dove il file del database sarà memorizzato
			// Utilizza 'AppDataDirectory' di MAUI per memorizzare il file in una directory accessibile all'app
			get => Path.Combine(FileSystem.AppDataDirectory, DbFileName);
		}
	}
}
