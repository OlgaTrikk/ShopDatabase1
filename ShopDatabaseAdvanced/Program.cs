using ShopDatabaseAdvanced.Models;
using ShopDatabaseAdvanced.ShopAdvancedDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDatabaseAdvanced
{
	class Program
	{
		static void Main(string[] args)
		{
			

			using (var db = new AdvancedShopDatabaseContext())
			{
				//db.Foods.AddRange(groceries);
				//db.SaveChanges();
			

				ShoppingCart newCart = new ShoppingCart();
				db.ShoppingCarts.Add(newCart);

				ChooseFood(db, newCart);
				while (Console.ReadLine() == "Yes")
				{
					ChooseFood(db, newCart);
				}

				db.SaveChanges();

				var shoppingCarts = db.ShoppingCarts.Include("Items").ToList();
				foreach(var cart in shoppingCarts)
				{
					Console.WriteLine($"Shopping cart created on {cart.DateCreated}");
					foreach(var food in cart.Items)
					{
						Console.WriteLine($"{food.Name} Price: {food.Price}");
					}
					Console.WriteLine($"Total: {cart.Sum}");
				}
			}

		
		}

		private static void ChooseFood(AdvancedShopDatabaseContext db, ShoppingCart newCart)
		{
			Console.WriteLine("What do you want to buy?");
			string foodName = Console.ReadLine();
			Food chosenFood = db.Foods.FirstOrDefault(x => x.Name == foodName);
			newCart.AddToCart(chosenFood);
			Console.WriteLine("Anything else? Yes/No");
		}
	}
}
