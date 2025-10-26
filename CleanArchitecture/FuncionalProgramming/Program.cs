
Console.WriteLine("Funcion no pura: " + Tomorrow());

Console.WriteLine("Funcion pura: " + TomorrowPure(new DateTime(2025,10, 25,00,00,00)));


//Funciones de primera clase
var t = TomorrowPure;
Console.WriteLine(t(new DateTime(2025, 10, 25, 00, 00, 00)));

var beer = new Beer()
{
    Name = "Heineken"
};

Console.WriteLine(ToUpper(beer).Name);
Console.WriteLine(ToUpperPure(beer).Name);
Console.WriteLine(beer.Name);

// Tipo Action
Action<string> show = Console.WriteLine;
show("Hola");

// Expresiones Lamdbas
Action<string> hi = name => Console.WriteLine($"Hola {name}");
hi("Anakin");

Action<int, int> add = (a, b) => show((a + b).ToString());
add(10, 12);

// Tipos Func
Func<int, int, int> mul = (a, b) => a * b;
show(mul(3, 4).ToString());

Func<int, int, string> mulString = (a, b) =>
{
    var res = a * b;
    return res.ToString();
};
show(mulString(6, 8));

// Tipo Predicado
Predicate<int> condition1 = x => x % 2 == 0;
Predicate<int> condition2 = x => x > 5;


// Funciones de orden superior
List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
var numbers2 = Filter(numbers, number => number % 2 == 0);
var numbers3 = Filter(numbers, number => number > 5);

var numbers4 = Filters(numbers, condition1);
var numbers5 = Filters(numbers, condition2);

Console.WriteLine("------");
foreach ( var number in numbers2)
{
    Console.WriteLine(number);
}
Console.WriteLine("------");
foreach (var number in numbers3)
{
    Console.WriteLine(number);
}
Console.WriteLine("------");
foreach (var number in numbers4)
{
    Console.WriteLine(number);
}
Console.WriteLine("------");
foreach (var number in numbers5)
{
    Console.WriteLine(number);
}



List<int> Filter(List<int> list, Func<int, bool> condition)
{
    var resultList = new List<int>();
    foreach(var element in list)
    {
        if(condition(element))
        {
            resultList.Add(element);
        }
    }
    return resultList;
}

List<int> Filters(List<int> list, Predicate<int> condition)
{
    var resultList = new List<int>();
    foreach (var element in list)
    {
        if (condition(element))
        {
            resultList.Add(element);
        }
    }
    return resultList;
}


DateTime Tomorrow()
{
    return DateTime.Now.AddDays(1);
}

Beer ToUpper(Beer beer)
{
    beer.Name = beer.Name.ToString();
    return beer;
}



// Funcion Pura
DateTime TomorrowPure(DateTime date)
{
    return date.AddDays(1);
}

Beer ToUpperPure(Beer berr)
{
    var beer2 = new Beer()
    {
        Name = beer.Name.ToUpper(),
    };

    return beer2;
}

public class Beer
{
    public string Name { get; set; }
}