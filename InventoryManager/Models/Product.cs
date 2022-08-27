using System;
using SQLite;

namespace InventoryManager.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string amount { get; set; }

        public int categoryId { get; set; }

        public DateTime date { get; set; }


    }
}

