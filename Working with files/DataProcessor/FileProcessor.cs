using static System.Console;

namespace DataProcessor;

public class FileProcessor
{
    public string InputFilePath { get; }

    public FileProcessor(string filePath) => InputFilePath = filePath;

    public void Process()
    {
        WriteLine($"Begin process of {InputFilePath}");

        if (!File.Exists(InputFilePath))
        {
            WriteLine($"ERROR: file {InputFilePath} doesn't exist.");
            return;
        }

        string? rootDirectoryPath = new DirectoryInfo(InputFilePath).Parent?.Parent?.FullName;

        WriteLine($"Root data path is {rootDirectoryPath}");
    }
}
