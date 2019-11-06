namespace ShopDatabaseAdvanced.Migrations
{
	using ShopDatabaseAdvanced.Models;
	using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopDatabaseAdvanced.ShopAdvancedDbContext.AdvancedShopDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ShopDatabaseAdvanced.ShopAdvancedDbContext.AdvancedShopDatabaseContext";
        }

        protected override void Seed(ShopDatabaseAdvanced.ShopAdvancedDbContext.AdvancedShopDatabaseContext context)
        {
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method
			//  to avoid creating duplicate seed data.
			//List<Food> groceries = new List<Food>
			//{
			//	new Food("apple", 1.7),
			//	new Food("bread", 1.2),
			//	new Food("cheese", 2),
			//	new Food("milk", 1),
			//	new Food("icecream", 1.5)
			//};

			context.Foods.AddOrUpdate(
				food => food.Name,
				new Food
				{
					Name = "apple",
					Price = 1.7
				},
				new Food
				{
					Name = "bread",
					Price = 1.2
				},
				new Food
				{
					Name = "cheese",
					Price = 2
				},
				new Food
				{
					Name = "milk",
					Price = 0.95
				},
				new Food
				{
					Name = "icecream",
					Price = 1.3
				},
				new Food
				{
					Name = "cake",
					Price = 2.5
				}
				);
			context.SaveChanges();
		}
	}
}
