using ShopDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDatabase
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Food> groceries = new List<Food>
			{
				new Food("apple", 1.7),
				new Food("bread", 1.2),
				new Food("cheese", 2)
			};

			ShoppingCart newCart = new ShoppingCart();

			//ChooseFood(groceries, newCart);
			//while (Console.ReadLine() == "Yes")
			//{
			//	ChooseFood(groceries, newCart);
			//}

			//foreach (var food in groceries)
			//{
			//	newCart.Items.Add(food);
			//}

			using (var db = new ShopDbContext())
			{
				IQueryable<ShoppingCart> cartsWithZeroSum = db.ShoppingCarts.Where(x => x.Sum == 0);
				foreach(var cart in cartsWithZeroSum)
				{
					db.ShoppingCarts.Remove(cart);
				}
				db.SaveChanges();

				db.ShoppingCarts.Add(newCart);
				db.SaveChanges();

				//var carts = db.ShoppingCarts.Include("Items").OrderByDescending(x => x.DateCreated).ToList();
				//foreach (var cart in carts)
				//{
				//	Console.WriteLine($"Shopping cart created on {cart.DateCreated}");
				//	foreach (var food in cart.Items)
				//	{
				//		Console.WriteLine($"Name: {food.Name}  Price: {food.Price}");
				//	}
				//	Console.WriteLine($"Total: {cart.Sum}");
				//}

				var carts = db.ShoppingCarts;
				var cartsWithItems = db.ShoppingCarts.Include("Items");
				var foods = db.Foods;

				//1. Last created cart
				var latest = cartsWithItems.OrderByDescending(cart => cart.DateCreated).ToList().First();
				var latest2 = cartsWithItems.OrderBy(cart => cart.DateCreated).ToList().Last();

				Console.WriteLine($"Shopping cart created on {latest.DateCreated}");
				Console.WriteLine($"Shopping cart created on {latest2.DateCreated}");
				Console.WriteLine("");

				//2. Carts with Sum > 5
				var carts5 = carts.Where(x => x.Sum > 5).ToList();
				foreach(var cart in carts5)
				{
					Console.WriteLine($"Shopping cart created on {cart.DateCreated} Sum: {cart.Sum} ");
				}

				// 3. Carts with more than 1 item (and show how many items are there)
				var cartsMoreThan1 = cartsWithItems.Where(x => x.Items.Count() > 1).ToList();
				foreach (var cart in cartsMoreThan1)
				{
					Console.WriteLine($"Shopping cart created on {cart.DateCreated} Items count: {cart.Items.Count()}");
				}

				var cartsMoreThan1_query = from cart in cartsWithItems where cart.Items.Count() > 1 select cart;
				foreach (var cart in cartsMoreThan1_query)
				{
					Console.WriteLine($"Shopping cart created on {cart.DateCreated} Items count: {cart.Items.Count()}");
				}
				Console.WriteLine("");

				// 4. Only carts that contain apples
				var cartsWithApples = cartsWithItems.Where(cart => cart.Items.Any(y => y.Name == "apple"));
				foreach(var cart in cartsWithApples)
				{
					Console.WriteLine($"Shopping cart created on {cart.DateCreated}");
					foreach(var food in cart.Items)
					{
						Console.WriteLine($"{food.Name}");
					}
				}

				// 5. Show the total number of shopping carts
				var count = carts.Count();
				Console.WriteLine($"Total number of carts is {count}");

				// 6. Show th cart with maximum sum
				var cartWithMaxSum = carts.OrderByDescending(x => x.Sum).FirstOrDefault();
				Console.WriteLine($"Cart created on {cartWithMaxSum.DateCreated} Sum: {cartWithMaxSum.Sum}");

				// 7. Show the cheapest food
				var cheapestFood = foods.OrderByDescending(food => food.Price).ToList().Last();
				Console.WriteLine($"Cheapest food is {cheapestFood.Name} Price {cheapestFood.Price}");
			}

		}

		private static void ChooseFood(List<Food> groceries, ShoppingCart newCart)
		{
			Console.WriteLine("What do you want to buy?");
			string foodName = Console.ReadLine();
			Food chosenFood = groceries.FirstOrDefault(x => x.Name == foodName);
			newCart.AddToCart(chosenFood);
			Console.WriteLine("Anything else? Yes/No");
		}
	}
}
