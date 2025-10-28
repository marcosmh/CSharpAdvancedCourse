var calculator = new Calculator(16);
Console.WriteLine(Calculator.PI);
Console.WriteLine(calculator.Value);

List<string> beers = new List<string>()
{
    "Weizen","Pils"
};

var brand = new Brand("Krombacher",beers);
var brandName = brand.Name;
Console.WriteLine(brandName);
var brand2 = brand.With("Erdinger");
Console.WriteLine(brand2.Name);
var brand3 = brand.With(beers: new List<string>() { "Light " });

var people = new
{
    Name = "Anakin",
    Age = 30,
    Country = "Toatine"
};



public class Brand
{
    public string Name { get; set; }

    public IReadOnlyList<string> Beers { get; }

    public Brand(string name, List<string> beers)
    {
        Name = name;
        Beers = beers;
    }

    public Brand With(string? name = null, List<string> beers = null)
    {
        return new Brand(name ?? this.Name, this.Beers.ToList());
    }
}

public class Calculator
{
    public const double PI = 3.1416;
    public readonly int Value;

    public Calculator(int value)
    {
        Value = value;
    }


}