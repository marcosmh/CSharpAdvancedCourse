using System;

namespace Object_orientedProgramming.Business
{
	public class Wine : Drink
	{
        private const string Category = "Vino";

		public Wine(int quantity) : base(quantity)
		{

		}

		public override string GetCategory() => Category;
    }
}

