using BenchmarkDotNet.Attributes;
using System.Globalization;

namespace Benchmarks;

[SimpleJob]
[MemoryDiagnoser]
public class SpanBenchmarker
{
    private string payload = string.Empty;

    [GlobalSetup]
    public void Setup()
    {
        payload = File.ReadAllText(@"Data\Stock");
    }

    [Benchmark]
    public decimal Process()
    {
        decimal result = 0;

        foreach (var line in payload.Split('\n').Skip(1))
        {
            int startIndex = 0;
            int endIndex = 0;

            for (int column = 0; column <= 8; column++)
            {
                endIndex = line.IndexOf(",", startIndex);

                if (column is 6 or 7)
                {
                    result += decimal.Parse(line[startIndex..endIndex], CultureInfo.InvariantCulture);
                }
                else if (column is 8)
                {
                    result += decimal.Parse(line[startIndex..], CultureInfo.InvariantCulture);
                }

                startIndex = endIndex + 1;
            }
        }

        return result;
    }

    [Benchmark]
    public decimal ProcessAsSpan()
    {
        var payloadAsSpan = payload.AsSpan();
        decimal result = 0;

        int lineStart = 0;
        int startOfFirstLineWithData = payloadAsSpan.IndexOf('\n') + 1;

        //Slice the span to start at the data row
        payloadAsSpan = payloadAsSpan[startOfFirstLineWithData..];

        while (true)
        {
            if (lineStart == -1) break;

            var currentPayload = payloadAsSpan[lineStart..];
            var endOfCurrentLine = currentPayload.IndexOf("\n");

            ReadOnlySpan<char> currentLine;

            // Need to handle if this is the last time in the file
            if (endOfCurrentLine < 0)
            {
                //Use all the available data
                currentLine = currentPayload[..];

                lineStart = -1;
            }
            else
            {
                lineStart += endOfCurrentLine + 1;
                currentLine = currentPayload[..endOfCurrentLine];
            }

            int columnStartIndex = 0;
            int columnEndIndex = 0;

            for (int column = 0; column <= 8; column++)
            {
                var currentColumnData = currentLine[columnStartIndex..];


                columnEndIndex = currentColumnData.IndexOf(',');

                //Handle last column
                if (column == 8)
                {
                    currentColumnData = currentColumnData[..];
                }
                else
                {
                    currentColumnData = currentColumnData[..columnEndIndex];
                }

                if (column is 6 or 7 or 8)
                {
                    result += decimal.Parse(currentColumnData, CultureInfo.InvariantCulture);
                }

                columnStartIndex += columnEndIndex + 1;
            }
        }

        return result;
    }
}
