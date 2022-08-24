using System;
using System.Diagnostics;
using InventoryManager.Models;
using SQLite;

namespace InventoryManager.Services
{
    public class UserService
    {
 
        public static async Task<SQLiteAsyncConnection> createTable()
        {
            var database = Database.Database.getDatabase();
            await database.CreateTableAsync<User>();

            return database;
           
        }

        public static async Task<int> AddUser(User user)
        {
            var database = await createTable();
            return await database.InsertAsync(user);
        }


        public static async Task<List<User>> GetUsers()
        {
            var database = await createTable();
            return await database.Table<User>().ToListAsync();

        }

        public static async Task<User> GetUserByUserName(string userName)
        {
            var database = await createTable();
            return await database.FindWithQueryAsync<User>("Select * from User Where userName = ?", userName);

        }

    }
}

