using System;
using SQLite;
namespace InventoryManager.Models
{
	public class User
	{
		[PrimaryKey,AutoIncrement]
		public int id { get; set; }
		public Role role { get; set; }
		public string password { get; set; }
		public string userName { get; set; }
		public DateTime date { get; set; }
	}

	public enum Role
	{
			Admin,
			User,
			Attendant

	}
}

