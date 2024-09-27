using StockAnalyzer.Processor;
using System.Diagnostics;

var watch = new Stopwatch();
watch.Start();

var result = string.Empty;

var processor = new Processor();

Console.WriteLine("Starting..");

processor.Initialize();

foreach (var stock in processor.Stocks)
{
    var min = processor.Min(stock.Key);
    var max = processor.Max(stock.Key);
    var average = processor.Average(stock.Key);

    result += $"{stock.Key},{min},{max},{average}{Environment.NewLine}";
}
File.WriteAllText("Result.txt", $"{result}");

Console.WriteLine("Completed..");

Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}ms");

Console.ReadLine();