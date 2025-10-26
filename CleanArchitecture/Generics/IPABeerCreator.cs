using System;
namespace Generics
{
	public class IPABeerCreator : IDrinkCreator<Beer>
	{
		public IPABeerCreator()
		{
		}

		public Beer Create(double quantity)
			=> new Beer("Cerveza IPA", quantity);
    }
}

