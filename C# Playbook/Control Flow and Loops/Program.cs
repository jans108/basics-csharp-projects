using System.Reflection;
using Pluralsight.CShPlaybook.ControlFlow;

string filePath = Assembly.GetEntryAssembly()!.Location;

Console.WriteLine("Entry assembly is " + Path.GetFileName(filePath));
Console.WriteLine("Folders are:");
FolderProcessor.DisplayParentNames_While(filePath);
return;

