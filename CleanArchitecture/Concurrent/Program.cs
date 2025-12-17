using Concurrent;

// Task

/*
Console.WriteLine("Inicia mi Programa");

var task = Task.Run(async () =>
{
    Console.WriteLine("Inicio de tarea asincrona");

    await Task.Delay(1000);

    Console.WriteLine("Fin de tarea asincrona");
});

Console.WriteLine("Hago algo Extra");

await task;

Console.WriteLine("Hago algo extra despues");

Console.WriteLine("Fin mi Programa");

*/


// async y await

/*
Console.WriteLine("INICIA mi Programa");

Console.WriteLine("Hago algo mas");

var task = Methods.Wait(1000);

await task;

Console.WriteLine("FIN mi Programa");
*/


// TResult

/*
var taskResult =  Methods.AddAsync(3, 5);

Console.WriteLine("Mientras hago algo");

var result = await taskResult;

Console.WriteLine("Mientras hago algo mas");
Console.WriteLine(result);
*/

// ContinueWith

/*
var tasks = Task.Run(() =>
{
    Console.WriteLine("Tarea inicial secuencial INICIA");

    var resultTask = Methods.AddAsync(5, 10);


    Console.WriteLine("Tarea inicial secuencial FINALIZA");

    return resultTask.Result;
}).ContinueWith((resultTask) =>
{
    Console.WriteLine("Tarea segunda secuencial INICIA");

    var result = resultTask.Result;
    Console.WriteLine($"El resultado es {result} ");

    Task.Delay(2000).Wait();

    Console.WriteLine("Tarea segunda secuencial FINALIZA");


});

await task;

Console.WriteLine("Fin de las tareas secuenciales");
*/

//WhenAll

/*
List<Task> waitTask = new List<Task>()
{
    Methods.Wait(1000),
    Methods.Wait(2000)

};

await Task.WhenAll(waitTask);

Console.WriteLine("terminaron las tareas de espera");

List<Task<double>> addTasks = new List<Task<double>>()
{
    Methods.AddAsync(10, 10),
    Methods.AddAsync(20, 20),
    Methods.AddAsync(30, 30)
};

double[] results = await Task.WhenAll(addTasks);

foreach(var res  in results)
{
    Console.WriteLine("Resultado " + res);
}

Console.WriteLine("terminaron las tareas de suma");
*/

// Thread

Thread thread = new Thread(() =>
{
    Console.WriteLine("INICIA Ejecución en Hilo");

    Thread.Sleep(6000);

    Console.WriteLine("FINALIZA Ejecución en Hilo");

});

Console.WriteLine("Inicio de Programa.");

thread.Start();

Console.WriteLine("El programa principal hace otra cosa.");

thread.Join();

Console.WriteLine("FIN de Programa.");


