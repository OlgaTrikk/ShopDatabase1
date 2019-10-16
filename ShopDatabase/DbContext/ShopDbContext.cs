using ShopDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDatabase
{
	public class ShopDbContext : DbContext
	{
		public DbSet<ShoppingCart> ShoppingCarts { get; set; }

		public DbSet<Food> Foods { get; set; }
	}
}
