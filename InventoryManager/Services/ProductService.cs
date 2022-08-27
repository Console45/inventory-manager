
using InventoryManager.Models;
using SQLite;

namespace InventoryManager.Services
{
    public class ProductService
    {
        public static async Task<SQLiteAsyncConnection> createTable()
        {
            var database = Database.Database.getDatabase();
            await database.CreateTableAsync<Product>();

            return database;

        }

        public static async Task<int> AddProduct(Product product)
        {
            var database = await createTable();
            return await database.InsertAsync(product);
        }


        public static async Task<List<Product>> GetProducts()
        {
            var database = await createTable();
            return await database.Table<Product>().ToListAsync();

        }

    }
}