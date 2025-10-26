using System;
namespace Generics
{
	public interface IDrinkCreator<out T>
	{
		T Create(double quantity);
	}
}

