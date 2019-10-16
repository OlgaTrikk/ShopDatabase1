using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDatabase.Models
{
	public class ShoppingCart
	{
		public Guid Id { get; set; }

		public double Sum { get; set; }

		public DateTime DateCreated { get; set; }

		public List<Food> Items { get; set; }

		public ShoppingCart()
		{
			Id = Guid.NewGuid();
			Items = new List<Food>();
			Sum = 0;
			DateCreated = DateTime.Now;
		}
	}
}
