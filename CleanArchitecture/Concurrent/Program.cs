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

/*
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

*/

// Parallel.For

/*
int numberOffFiles = 100;

Parallel.For(0, numberOffFiles, i =>
{
    string fileName = $"archivo_{i}.txt";
    string content = $"archivo numero {i}.";

    File.WriteAllText(fileName, content);

    Console.WriteLine($"Archivo '{fileName} creado por el hilo: {Task.CurrentId}. ");

});
*/

// Parallel.ForEach

/*
List<int> ids = new List<int>()
{
    16,8,22,23,60,23,6,27,28,76,71,86,64
};

Parallel.ForEach(ids, id =>
{
    string fileName = $"archivo_{id}.txt";
    string content = $"archivo numero {id}.";
    File.WriteAllText(fileName, content);
    Console.WriteLine($"Archivo '{fileName} creado por el hilo: {Task.CurrentId}. ");

});

Console.WriteLine($"Se ha terminado de hacer todos los procesos. ");
*/

// Parallel.ForEachAsync

List<int> episodes = new List<int>
{
    1,6,7,2,10,22,64,33,22,16
};

var url = "https://rickandmortyapi.com/api/episode/";
var httpClient = new HttpClient();

await Parallel.ForEachAsync(episodes, async (episode, CancellationToken) =>
{
    try
    {
        int threadId = Thread.CurrentThread.ManagedThreadId;

        HttpResponseMessage response = await httpClient.GetAsync(url + episode);
        string responseBody = await response.Content.ReadAsStringAsync();

        string fileName = $"episode{episode}.txt";

        await File.WriteAllTextAsync(fileName, responseBody);

        Console.WriteLine($"Archivo '{fileName} creado por el hilo: {threadId}. ");

    } catch(Exception ex)
    {
        Console.WriteLine($"Error al solicitar {url}: {ex.Message} ");
    }

}); Console.WriteLine($"Se ha terminado de hacer todos los procesos. ");