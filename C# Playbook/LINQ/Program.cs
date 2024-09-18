using Pluralsight.CShPlaybook.LinqDemos;

var students = ResultsRepository.EnumStudents();
var results = ResultsRepository.EnumResults()
    .Distinct(ExamResultEqualityComparer.Instance)
    .OrderBy(result => result.Subject);

IEnumerable<(Student student, IEnumerable<ExamResult>)> studentResults =
    from Student student in students
    orderby student.Name
    join ExamResult result in results on student.AnonymousId equals result.StudentId
    into resultsByStudent
    select (student, resultsByStudent);

var studentResultsFluent = students
    .GroupJoin(results,
    student => student.AnonymousId,
    result => result.StudentId,
    (student, result) => (student, result))
    .OrderBy(tuple => tuple.student.Name);


foreach ((Student student, IEnumerable<ExamResult> resultsForStudent) in studentResults) 
{
    Console.WriteLine(student.Name);
    foreach (ExamResult result in resultsForStudent)
        Console.WriteLine($"  {result.Mark:##}% in {result.Subject}");
}



Console.ReadLine();