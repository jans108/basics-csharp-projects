using static System.Console;

namespace DataProcessor;

public class FileProcessor
{
    private const string BackupDirectoryName = "backup";
    private const string InProgressDirectoryName = "processing";
    private const string CompletedDirectoryName = "complete";

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
        if ( rootDirectoryPath is null ) 
        {
            throw new InvalidOperationException($"Cannot determine root directory path");
        }

        WriteLine($"Root data path is {rootDirectoryPath}");

        //Check if backup directory exists
        string backupDirectoryPath = Path.Combine( rootDirectoryPath, BackupDirectoryName );

        if (!Directory.Exists(backupDirectoryPath))
        {
            WriteLine($"Creating {backupDirectoryPath}");
            Directory.CreateDirectory(backupDirectoryPath);
        }

        //Copy file to backup dir
        string inputFileName = Path.GetFileName(InputFilePath);
        string backupFilePath = Path.Combine( backupDirectoryPath, inputFileName);
        WriteLine($"Copying {InputFilePath} to {backupFilePath}");
        File.Copy(InputFilePath, backupFilePath, true);
    }
}
