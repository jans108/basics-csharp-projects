using Pluralsight.CShPlaybook.LinqDemos;

var resultsByStudent = GroupByStudent();

var flatResults = from grouping in resultsByStudent
                  from result in grouping
                  orderby result.StudentId, result.Subject
                  select result;


foreach (var result in flatResults)
    Console.WriteLine(result);

Console.ReadLine();

static IEnumerable<IGrouping<int, ExamResult>> GroupByStudent()
{
    var resultDistinct = ResultsRepository.EnumResults().Distinct(ExamResultEqualityComparer.Instance);

    var resultsByStudent =
        from result in resultDistinct
        group result by result.StudentId;
    return resultsByStudent;
}