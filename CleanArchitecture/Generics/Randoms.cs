using System;
namespace Generics
{
	public class Randoms
	{
		private double _number;

		public double Number
		{
			get => _number;
		}

		public Randoms()
		{
			_number = new Random().NextDouble();
		}
	}
}

