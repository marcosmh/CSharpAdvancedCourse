using System;
namespace Generics
{
	public class DrinkShow : IShow<Drink>
	{
		public DrinkShow()
		{
		}

		public void Show(Drink drink)
			=> Console.WriteLine("cantidad: " + drink.Quantity + " ml"); 
    }
}

