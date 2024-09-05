namespace Pluralsight.CShPlaybook.ControlFlow;

public class FolderProcessor
{
	public static void DisplayParentNames_While(string filePath)
	{
		var folder = new DirectoryInfo(Path.GetDirectoryName(filePath)!);
		while (folder != null)
		{
			Console.WriteLine(folder.Name);
			folder = folder.Parent;
		}
	}
}

