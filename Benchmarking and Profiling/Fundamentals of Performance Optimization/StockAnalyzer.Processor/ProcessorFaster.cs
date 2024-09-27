using System.Globalization;

namespace StockAnalyzer.Processor;

public class ProcessorFaster(string dataPath = "Data")
{
    public Dictionary<string, (int Count, 
        decimal Min,
        decimal Max, 
        decimal Average,
        decimal Total)> Stocks { get; } = [];

    public void Initialize()
    {
        foreach (var file in Directory.GetFiles(dataPath))
        {
            using var reader = new StreamReader(File.Open(file, FileMode.Open, FileAccess.Read));
            reader.ReadLine(); // Skip first line;

            while(reader.ReadLine() is string line)
            {
                ReadOnlySpan<char> lineAsSpan = line;

                var name = lineAsSpan[..line.IndexOf(',')].ToString();

                var start = line.IndexOf(",,,,,");
                start = line.IndexOf(',', start + 6) + 1;
                var changeText = lineAsSpan[start..line.IndexOf(',', start + 1)];

                var change = decimal.Parse(changeText, CultureInfo.InvariantCulture);

                if (!Stocks.ContainsKey(name))
                {
                    Stocks[name] = (1, change, change, change, change);
                }
                else
                {
                    var trade = Stocks[name];
                    var min = change < trade.Min ? change : trade.Min;
                    var max = change > trade.Max ? change : trade.Max;
                    var total = trade.Total + change;
                    var count = trade.Count + 1;
                    var average = total / count;

                    Stocks[name] = (count, min, max, average, total);
                }
            }
        }
    }
}
