using ExtensionMethods;

int number = 10;
int number2 = number.X2();
Console.WriteLine(number2);

var sale = new Sale(16);
Console.WriteLine(sale.GetInfo());

int num = 20;
Console.WriteLine(num.Mul(num));

List<int> numbers = new List<int>() { 15, 20, 30, 55 };
Console.WriteLine(num.Exists(numbers));

string name = "Markcode";
List<string> names = new List<string>() { "Juan", "Pedro", "Yolanda" };
Console.WriteLine(name.Exists(names));
Console.WriteLine("--------");
Console.WriteLine(name.IsOn(names));

Console.WriteLine("--------");
var beer = new Beer() { Quantity = 500 };
var wine = new Wine() { Quantity = 1000 };
Console.WriteLine(beer.GetDescription());
Console.WriteLine(wine.GetDescription());

Console.WriteLine("--------");
beer.SetBrand("Fullers")
    .SetName("London Porter")
    .SetQuantity(500);




public static class IntOperations
{
    public static int X2(this int number)
        => number * 2;

    public static int Mul(this int number, int multiplier)
        => number * multiplier;
}

public static class SaleExtentions
{
    public static string GetInfo(this Sale sale)
        => "El monto es $ " + sale.Amount;
}

public static class ListExtensions
{
    public static bool Exists<T>(this T element, List<T> list)
    {
        foreach(T item in list)
        {
            if (item.Equals(element))
            {
                return true;
            }
        }

        return false;
    }

    public static bool IsOn<T>(this T element, List<T> list) where T: class
    {
        foreach (T item in list)
        {
            if (item.Equals(element))
            {
                return true;
            }
        }

        return false;
    }


}

public interface IDrink
{
    public decimal Quantity { get; }
}

public static class DrinkExtensions
{
    public static string GetDescription(this IDrink drink)
        => $"La bebida tiene {drink.Quantity} ml";
}

public class Beer : IDrink
{
    public decimal Quantity { get; set; }

    public string Name { get; set; }

    public string Brand { get; set; }
}

public class Wine : IDrink
{
    public decimal Quantity { get; set; }
}

public static class BeerExtensions
{
    public static Beer SetQuantity(this Beer beer, decimal quantity)
    {
        beer.Quantity = quantity;
        return beer;
    }

    public static Beer SetName(this Beer beer, string name)
    {
        beer.Name = name;
        return beer;
    }

    public static Beer SetBrand(this Beer beer, string brand)
    {
        beer.Brand = brand;
        return beer;
    }

}