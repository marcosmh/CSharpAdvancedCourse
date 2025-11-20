using System.Text.RegularExpressions;
using AdvancedFunctionalProgramming;

var sum = Closure.SumClosure();
var sum2 = Closure.SumClosure();

sum(1, 2);
sum(3, 2);

sum2(4, 6);
sum2(7, 8);



var fn = Closure.DelayExecutor(3000, () => Console.WriteLine("Ejecucion de funcion"));
fn();

//Map
Console.WriteLine("*** Map ***");
List<int> numbers = new List<int>()
{
    1,2,3,4,5,6,7,8,9,10
};

//var stringNumbers = numbers.Map<int, string>( (item) => $"El numero es {item}" );
var stringNumbers = numbers.Map((item) => $"El numero es {item}");

foreach (var item in stringNumbers)
{
    Console.WriteLine(item);
}

Console.WriteLine("*** Filter ***");
var max5Numbers = numbers.Filter((item) => item > 5);
foreach (var item in max5Numbers)
{
    Console.WriteLine(item);
}

Console.WriteLine("*** Reduce ***");
var total = numbers.Reduce((acc, item) => acc + item, 0);
Console.WriteLine(total);

//Composicion
Console.WriteLine("*** Composicion ***");
Func<double, double, double> add = (a, b) => a + b;
Func<double, double> mulX2 = (a) => a * 2;
Func<double, double, double> mul = (a, b) => a * b;

Func<double, double, double> addAndMulX2 = (a, b) => mulX2(add(a, b));

var result = addAndMulX2(5, 10);
Console.WriteLine(result);

Func<double, double, double, double> addAndMul = (a, b, c) => mul(add(a, b), c);
var result2 = addAndMul(5, 10, 3);
Console.WriteLine(result2);

Func<int, string> toString = (x) => $"Number : {x} ";
Func<int, bool> max5 = (x) => x > 5;

Func<List<int>, List<string>> numbersMax5AndString = (lst)
    => ListExtensions.Map(ListExtensions.Filter(lst, max5), toString);

var numbersResult = numbersMax5AndString(numbers);
//numbersResult.ForEach((e) => Console.WriteLine(e));
numbersResult.ForEach(Console.WriteLine);

//Pipes
Console.WriteLine("*** Pipes ***");
Func<string, string> removeSpace = (s) => s.Replace(" ", "");
Func<string, string> firstCapitalLetter = (s) => char.ToUpper(s[0]) + s.Substring(1);
Func<string, string> removeNumber = (s) => Regex.Replace(s, @"\d", "");

string text = "ro1789271827    ber0891208291  198to";
var cleanText = Functions.PipeString(text, removeSpace, firstCapitalLetter, removeNumber);
var cleanText2 = Functions.Pipe(text, removeSpace, firstCapitalLetter, removeNumber);
var numbersXPipe = Functions.Pipe(numbers,
    lst => lst.Map(e => e * 2),
    lst => lst.Map(e => e - 1)
 );

var numberXPipe = numbers
    .P(lst => lst.Map(e => e * 2))
    .P(lst => lst.Map(e => e - 1))
    .P(lst => lst.Reduce( (ac,item ) => ac + item, 0));


Console.WriteLine(cleanText);
Console.WriteLine(cleanText2);
numbersXPipe.ForEach(Console.WriteLine);
Console.WriteLine(numberXPipe);

// Curriying
Console.WriteLine("*** Curriying ***");
Func<string, Func<string, string>> Concat()
{
    return a => b => a +" "+ b;
}

var concat = Concat();
var concatWithHi = concat("Hola");
Console.WriteLine(concatWithHi("Anakin"));
Console.WriteLine(concatWithHi("Luke"));

Func<decimal, Func<decimal, Func<decimal, decimal>>> calculateTotal =
    basePrice => tax => discount => (basePrice + (basePrice * tax) - discount);


var basePrice = 100;
var tax = 0.1m;
var discount = 20;

var calculateWithBasePrice = calculateTotal(basePrice);
var calculateWithTax = calculateWithBasePrice(tax);
var amount = calculateWithTax(discount);
var amountWithoutTax = calculateWithBasePrice(0)(discount);
var amountWithoutTaxAndDiscount = calculateWithBasePrice(0)(0);
var amount2 = calculateWithBasePrice(0.2m)(0);


Console.WriteLine($"El total es $ {amount}");
Console.WriteLine($"El total sin impuestos $ {amountWithoutTax}");
Console.WriteLine($"El total sin impuestos ni descuento $ {amountWithoutTaxAndDiscount}");
Console.WriteLine($"El total 2 es $ {amount2}");

// Memorization
//Console.WriteLine("*** Memorization ***");
//var pow = Memorization.Pow(2);
//Console.WriteLine(pow(2));
//Console.WriteLine(pow(2));
//Console.WriteLine(pow(2));
//Console.WriteLine(pow(3));
//Console.WriteLine(pow(3));


//Console.WriteLine("*** Memorization caso real ***");
//var requestAsync = Memorization.GetUrl("https://jsonplaceholder.typicode.com/posts");
//Console.WriteLine(await requestAsync(1));
//Console.WriteLine(await requestAsync(1));
//Console.WriteLine(await requestAsync(1));

Console.Clear();
//Console.WriteLine("*** Memorization Generics ***");
//var mulX5 = (double x) => x * 5;
//var mem = Memorization.Mem(mulX5);
//Console.WriteLine(mem(2));
//Console.WriteLine(mem(2));


Console.WriteLine("*** Memorization Asyncrona ***");
var getUrl = async (string url) =>
{
    using (var client = new HttpClient())
    {
        var response = await client.GetAsync(url);
        var responseBody = await response.Content.ReadAsStringAsync();
        return responseBody;

    }
};

//var memAsync = Memorization.MemAsync(getUrl);
//Console.WriteLine(await memAsync("https://jsonplaceholder.typicode.com/posts/1"));
//Console.WriteLine(await memAsync("https://jsonplaceholder.typicode.com/posts/1"));

Console.WriteLine("*** Functor ***");
var identity = new Identity<int>(55);
var newIdentity = identity.Map<string>(x => "Es un numero envuelto " + x.ToString());
Console.WriteLine(newIdentity.GetValue());

var beerPrice = new Identity<double>(100);
var beerTax = 0.1;
var beerDiscount = 15;

var totalPrice = beerPrice
    .Map(x => x + (x * beerTax))
    .Map(x => x - beerDiscount)
    .Map(x => "El resultado es " + x.ToString());

Console.WriteLine(totalPrice.GetValue());
Console.WriteLine(beerPrice.GetValue());

Console.WriteLine("*** MaybeFunctor ***");
var numberMFString = MaybeFunctor<int>
    .Some(8)
    .Map(x => x * 2)
    .Map(x => $"El maybe number es {x}");

Console.WriteLine(numberMFString.GetValue());

Console.WriteLine("*** MaybeMonad ***");
MaybeMonad<int> Div(int num, int div)
{
    if(div == 0)
    {
        return MaybeMonad<int>.None();
    }
    return MaybeMonad<int>.Some(num / div);
}

MaybeMonad<int> Add(int num1, int num2)
{
    if (num1 < 0 || num2 < 0)
    {
        return MaybeMonad<int>.None();
    }
    return MaybeMonad<int>.Some(num1 + num2);
}

var numberMM = MaybeMonad<int>.Some(80)
    .Bind(x => Div(x, 0))
    .Bind(x => Add(x, 2));

Console.WriteLine(numberMM);


var myBeer = Search(1)
    .Bind(x => validateName(x.Name));

Console.WriteLine(myBeer);

var myBeer2 = Search(11)
    .Bind(x => validateName(x.Name));

Console.WriteLine(myBeer2);


MaybeMonad<Beer> Search(int id)
{
    if(id == 1)
    {
        return MaybeMonad<Beer>.Some(
            new Beer()
            {
                Id = 1,
                Name = "Erdinger",
                Alcohol = 8
            }
        );
    }
    return MaybeMonad<Beer>.None();
}




MaybeMonad<string> validateName(string name)
{
    if(string.IsNullOrEmpty(name))
    {
        return MaybeMonad<string>.None();
    }
    return MaybeMonad<string>.Some(name);
}


class Beer
{
    public int Id { get; set; }
    public String Name { get; set; }
    public int Alcohol { get; set; }
}