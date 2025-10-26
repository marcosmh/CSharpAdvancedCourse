using System;
namespace Generics
{
	public class Drink
	{
		private double _quantity;

		public double Quantity
		{
			get => _quantity;
		}

		public Drink(double quantity)
			=> _quantity = quantity;


	}
}

