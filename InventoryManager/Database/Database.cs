using System;
using SQLite;

namespace InventoryManager.Database
{
	public abstract class Database
	{

        private static SQLiteAsyncConnection _database;


        public static SQLiteAsyncConnection getDatabase()
		{

            if (_database == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "InventoryManager.db3");
                _database = new SQLiteAsyncConnection(dbPath);
               

            }
            return _database;


    }

}
}

