using System;
namespace Generics
{
	public class Beer : Drink, IInfo
	{
		private string _name;

		public string Name
		{
			get => _name;
		}

		public Beer(string name, double quantity): base(quantity)
			=> _name = name;

		public string GetInfo()
			=> _name + " " + Quantity + " ml";
    }


}

