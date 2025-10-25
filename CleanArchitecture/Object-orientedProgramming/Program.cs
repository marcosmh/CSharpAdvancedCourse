using System.Xml.Linq;
using Object_orientedProgramming.Business;


Beer erdingerBeer = new Beer("Erdinger", 3, -2,1000);

var coronaBeer = new Beer("Corona",4.1m, 1,330);

Console.WriteLine(erdingerBeer.Name);
//Console.WriteLine(erdingerBeer.Price);
Console.WriteLine(erdingerBeer.SAlcohol);

//Console.WriteLine(coronaBeer.Name + " $ " + coronaBeer.Price);
Console.WriteLine(erdingerBeer.GetInfo());
Console.WriteLine(coronaBeer.GetInfo());

var delirium = new ExpiringBeer("Delirium", 4, 8,
    new DateTime(2025, 12, 01),1000);

Console.WriteLine(delirium.GetInfo());
Console.WriteLine(delirium.GetInfo("Una cerveza que caduca: "));
Console.WriteLine(delirium.GetInfo(2));
Console.WriteLine(delirium.GetCategory());

Drink drink = new Beer("Erdinger", 5, 1, 1000);
Console.WriteLine(drink.GetQuantity());
Console.WriteLine(drink.GetCategory());


Drink drink1 = new Wine(500);
Show(drink1);
drink1 = new Beer("Bohemia", 2, 4, 330);
Show(drink1);
Show(erdingerBeer);
SendSome(erdingerBeer);
SendSome(delirium);

var service = new Service(100, 10);
ISalable[] concepts = {
    erdingerBeer,
    delirium,
    service
};

Console.Clear();
Console.WriteLine(GetTotal(concepts));

var elements = new Collection<int>(3);
elements.Add(100);
elements.Add(150);
elements.Add(200);
elements.Add(500);
foreach(var element in elements.Get())
{
    Console.WriteLine(element);
}

var names = new Collection<string>(2);
names.Add("Anakin");
names.Add("Luke");
names.Add("R2D2");
foreach(var name in names.Get())
{
    Console.WriteLine(name);
}

var beers = new Collection<Beer>(2);
beers.Add(erdingerBeer);
beers.Add(delirium);
foreach (var beer in beers.Get())
{
    Console.WriteLine(beer.GetInfo());
}

Console.WriteLine($"Objetos Creados: {Beer.QuantityObjects}");

Console.WriteLine(Operations.Add(1, 2));
Console.WriteLine(Operations.Mul(10, 20));


void Show(Drink drink)
    => Console.WriteLine(drink.GetCategory());

void SendSome(ISend some)
{
    Console.WriteLine("Hago algo");
    some.Send();
    Console.WriteLine("Hago algo mas");
}

decimal GetTotal(ISalable[] concepts)
{
    decimal total = 0;
    foreach(var concept in concepts)
    {
        total += concept.GetPrice();
    }

    return total;
}

