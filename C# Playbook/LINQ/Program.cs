using Pluralsight.CShPlaybook.LinqDemos;

var resultDistinct = ResultsRepository.EnumResults().Distinct(ExamResultEqualityComparer.Instance);

var resultsByStudent =
    from result in resultDistinct
    group result by result.StudentId;

//Fluent syntax:
//var resultsByStudentFluent = resultDistinct.GroupBy(s => s.StudentId);

foreach (IGrouping<int, ExamResult> resultGroup in resultsByStudent)
{
    Console.WriteLine($"Student {resultGroup.Key}:");
    foreach (var result in resultGroup)
        Console.WriteLine($@"   {result.Mark:##}% in {result.Subject}");
}

Console.ReadLine();

