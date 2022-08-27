

using SQLite;

namespace InventoryManager.Models
{
    public class Category
    {
        [PrimaryKey, AutoIncrement]

        public string id { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }


    }
}