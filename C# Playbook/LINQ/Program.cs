using Pluralsight.CShPlaybook.LinqDemos;

var students = ResultsRepository.EnumStudents();
var results = ResultsRepository.EnumResults()
    .Distinct(ExamResultEqualityComparer.Instance);

IEnumerable<(Student, double)> studentAverages =
    from student in students
    join result in results on student.AnonymousId equals result.StudentId
    into resultsByStudent
    let avg = resultsByStudent.Average(x => x.Mark)
    orderby avg descending
    select (student, avg);

var studentAveragesFluent = students
    .GroupJoin(
    results,
    student => student.AnonymousId,
    r => r.StudentId,
    (s, r) => (s, r.Average(r => r.Mark)))
    .OrderBy(t => t.s.Name);

foreach ((Student student, double avg) in studentAverages)
    Console.WriteLine($"{student.Name.PadRight(10)}: {avg:##.#}%");




Console.ReadLine();