var beer = new Beer("Celebrator",new Brand("Ayinger"));
var beer2 = new Beer("Erdinger", new Brand("Erdinger"));
var beer3 = new Beer("celebrator", new Brand("Ayinger"));

Console.WriteLine(beer.Name);
Console.WriteLine(beer == beer2);
Console.WriteLine(beer == beer3);

//var (name, alcohol, brand) = beer;
//Console.WriteLine(brand.Name);

//var (n, _, _) = beer;
//Console.WriteLine($"Nombre: {n} ");


var mexico = new Country("Mexico") { Population = 130000000 };
mexico.Population = 131000000;

var beer4 = beer with { Name = "Lager Hell" };


record Beer(string Name, Brand brand);

record Brand(string Name);

record Country(string name)
{
    public int Population { get; set; }
}
