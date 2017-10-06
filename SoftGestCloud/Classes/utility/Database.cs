using System;
using SQLite;

namespace Utility
{
	public class Database
	{
		protected readonly SQLiteAsyncConnection connection;

		public Database(string dbpath)
		{
			connection = new SQLiteAsyncConnection(dbpath);
			//connection.CreateTableAsync<Configuration>().Wait();
		}

		public SQLiteAsyncConnection GetConnection()
		{
			return this.connection;
		}
	}
}

