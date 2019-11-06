using ShopDatabaseAdvanced.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDatabaseAdvanced.ShopAdvancedDbContext
{
	class AdvancedShopDatabaseContext : DbContext
	{
		public AdvancedShopDatabaseContext() : base("AdvancedShopDatabase")
		{		
		}

		public DbSet<ShoppingCart> ShoppingCarts { get; set; }

		public DbSet<Food> Foods { get; set; }
	}
}
