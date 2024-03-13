
using System;
using System.Threading;
using System.Threading.Tasks;

Console.WriteLine("Starting");

var task = Task.Factory.StartNew(async () =>
{
    await Task.Delay(2000);

    return "PS";
}).Unwrap();

var result = await task;

Console.WriteLine("Completed");

Console.ReadLine();