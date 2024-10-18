using Microsoft.Maui.Storage;
using SQLite;

namespace SqliteConnectionLib
{
	public static class Constants
	{
		private const string DbFileName = "Sqlie.db3";

		public const SQLiteOpenFlags flags =
			SQLiteOpenFlags.ReadWrite |
			SQLiteOpenFlags.Create |
			SQLiteOpenFlags.SharedCache;


		public static string DatabasePath
		{
			get => Path.Combine(FileSystem.AppDataDirectory, DbFileName);
		}
	}
}
