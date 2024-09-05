namespace Pluralsight.CShPlaybook.ControlFlow;

public class FolderProcessor
{
    public static IEnumerable<string> EnumParentNames_While(string filePath)
    {
        var folder = new DirectoryInfo(Path.GetDirectoryName(filePath));
        while (folder != null)
        {
            yield return folder.Name;
            folder = folder.Parent;
        }
    }

    public static IEnumerable<string> EnumParentNames_DoWhile(string filePath)
    {
        var folder = new DirectoryInfo(Path.GetDirectoryName(filePath));
        do
        {
            yield return folder.Name;
            folder = folder.Parent;
        }
        while (folder != null);
    }

    public static IEnumerable<string> EnumParentNames_For(string filePath)
    {
        for (var folder = new DirectoryInfo(Path.GetDirectoryName(filePath)!); folder != null; folder = folder.Parent)
        {
            yield return folder.Name;
        }
    }
}

