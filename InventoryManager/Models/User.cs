using System;
using InventoryManager.Services;
using SQLite;
namespace InventoryManager.Models
{
	public class User
	{
		[PrimaryKey, AutoIncrement]
		public int id { get; set; }
		public Role role { get; set; }
		public string password { get; set; }
		public string userName { get; set; }
		public DateTime date { get; set; }
        public static IEnumerable<Models.User> All { get; private set; }


        static User()
		{

		}

		static async void run()
		{
           All = await UserService.GetUsers();
        }
	}

	public enum Role
	{
			Admin,
			User,
			Attendant

	}
}

