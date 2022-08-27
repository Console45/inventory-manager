
using System;
using System.Diagnostics;
using InventoryManager.Models;
using SQLite;

namespace InventoryManager.Services
{
    public class CategoryService
    {
        public static async Task<SQLiteAsyncConnection> createTable()
        {
            var database = Database.Database.getDatabase();
            await database.CreateTableAsync<Category>();

            return database;

        }

        public static async Task<int> AddCategory(Category category)
        {
            var database = await createTable();
            return await database.InsertAsync(category);
        }


        public static async Task<List<Category>> GetCategories()
        {
            var database = await createTable();
            return await database.Table<Category>().ToListAsync();

        }

        public static async Task<Category> GetCategoryByName(string name)
        {
            var database = await createTable();
            return await database.FindWithQueryAsync<Category>("Select * from Category Where name = ?", name);

        }

    }
}