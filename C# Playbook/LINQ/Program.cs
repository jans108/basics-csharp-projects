using Pluralsight.CShPlaybook.LinqDemos;

Console.WriteLine("Setting up the query...");
var students = ResultsRepository
    .EnumStudents()
    .Take(3)
    .Thottle()
    .Log()
    .ToList();


Console.WriteLine("\r\nDisplaying results:");
foreach (Student student in students)
    Console.WriteLine("Outputting student: " + student);

Console.WriteLine("\r\nDisplaying results again...");
foreach (var student in students)
    Console.WriteLine("Outputting student:" + student);

Console.ReadLine();