using Pluralsight.CShPlaybook.LinqDemos;

IEnumerable<ExamResult> results = 
	from result in ResultsRepository.EnumResults().Distinct(ExamResultEqualityComparer.Instance)
    orderby result.StudentId, result.Subject
    select result;

foreach (ExamResult result in results)
	Console.WriteLine(result);
	
Console.ReadLine();

