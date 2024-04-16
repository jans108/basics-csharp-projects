using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor;

public class TextFileProcessor
{
    public string InputFilePath { get; }
    public string OutputFilePath { get; }

    public TextFileProcessor(string inputFilePath, string outputFilePath)
    {
        InputFilePath = inputFilePath;
        OutputFilePath = outputFilePath;
    }

    public void Process()
    {
        // Using read all text
        string originalText = File.ReadAllText(InputFilePath);
        string processedText = originalText.ToUpperInvariant();
        File.WriteAllText(OutputFilePath, processedText);
    }
}
