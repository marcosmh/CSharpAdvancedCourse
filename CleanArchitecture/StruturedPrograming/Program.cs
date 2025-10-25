// Variables

int number = 16;
number = 20;
float dec = 12.4f;
double deci = 13.3;
bool thereIsBeer = false;
string name = "markcode";
char letter = 'c';

var num = 17;
var name2 = "Pedro";

//Arrays
int[] numbers = new int[5];
numbers[0] = 1;
numbers[1] = 2;
numbers[2] = 3;
numbers[3] = 4;
numbers[4] = 5;

var numbers2 = new int[5] {1 ,2,3,4,5 };
Console.WriteLine(numbers2[2]);

//Sentencias Condicionales
Console.WriteLine("*** Sentencias Condicionales ***");

Console.WriteLine("IF - ELSE IF - ELSE");
var age = 12;

if( age > 60)
{
    Console.WriteLine("Es de la tercera edad");
}
else if(age > 18)
{
    Console.WriteLine("Es mayor de edad.");
}
else
{
    Console.WriteLine("Es menor de edad.");
}

Console.WriteLine("SWITCH");
switch (age)
{
    case < 18:
        Console.WriteLine("Es menor de edad.");
        break;
    case < 60:
        Console.WriteLine("Es mayor de edad.");
        break;
    default:
        Console.WriteLine("Es de la tercera edad");
        break;
}

// Sentencias de Iteracion
Console.WriteLine("*** Sentencias de Iteracion ***");
var names = new string[3]
{
    "Anakin", "Luke","R2D2"
};

Console.WriteLine("DO WHILE =>");
int i = 0;
do
{
    Console.WriteLine(names[i]);
    i++;
} while (i < names.Length);

Console.WriteLine("WHILE =>");
while ( i < names.Length )
{
    Console.WriteLine(names[i]);
    i++;
}

Console.WriteLine("FOR =>");
for (int j = 0; j < names.Length; j++)
{
    Console.WriteLine(names[j]);
}

// FUNCIONES
Console.WriteLine("*** FUNCIONES ***");

int res1 = Area(30);
int res2 = Area(20);

int res3 = Area(40);
Console.WriteLine(res3);
Show("Hola C#");
Bye();


int Area( int s )
{
    int res = s * s;
    return res;
}

void Show(string message)
{
    Console.WriteLine(message);
}

void Bye()
{
    Show("Adios!");
}

// Ejemplo de programa con paradigma estructurado

int limit = 10;
var beers = new string[limit];
int iBeers = 0;
int op = 0;

do
{
    Console.Clear();
    ShowMenu();
    op = int.Parse(Console.ReadLine());

    switch(op)
    {
        case 1:
            if(iBeers < limit)
            {
                Console.Clear();
                Console.WriteLine("Escribe el nombre de la cerveza");
                var beer = Console.ReadLine();
                beers[iBeers] = beer;
                iBeers++;
            }
            else
            {
                Console.WriteLine("Ya no caben cervezas.");
                Console.ReadLine();
            }
            break;
        case 2:
            ShowBeers(beers, iBeers);
            break;
        case 3:
            Console.WriteLine("Adios");
            break;
        default:
            Console.WriteLine("Opcion no valida!.");
            break;
    }

} while (op != 3);

void ShowMenu()
{
    Console.WriteLine("1. Agregar un nombre");
    Console.WriteLine("2. Mostrar nombres");
    Console.WriteLine("3. Salir");
}

void ShowBeers(string[] beers, int iBeers)
{
    Console.Clear();
    Console.WriteLine("---- Cervezas -----");
    for(int i = 0; i < iBeers; i++)
    {
        Console.WriteLine(beers[i]);
        
    }
    Console.ReadLine();
}