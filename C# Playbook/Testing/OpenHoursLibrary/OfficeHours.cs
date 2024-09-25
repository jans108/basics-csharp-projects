namespace Pluralsight.CShPlaybook.OpenHoursLibrary;
public class OfficeHours
{
    public IReadOnlyList<OpenPeriod> OpenHoursToday { get; private init; }
    public IReadOnlyList<OpenPeriod> OpenHoursTomorrow { get; private init; }
    public OfficeHours(IHoursRepository dataSource)
    {
        OpenHoursToday = dataSource.GetTodayOpenHours();
        OpenHoursTomorrow = dataSource.GetTomorrowOpenHours();
    }

    public TimeSpan GetTotalOpenHoursToday()
    {
        IEnumerable<TimeSpan> openTimeSpans =
            from duration in OpenHoursToday select duration.ClosedTime - duration.OpenTime;
        return SumTimeSpans(openTimeSpans);
    }
    public static TimeSpan SumTimeSpans(IEnumerable<TimeSpan> sequence)
    {
        TimeSpan result = new();
        foreach (TimeSpan t in sequence)
            result += t;
        return result;
    }

    public TimeSpan GetTimeUntilNextOpen(ITimeNowProvider timeNowProvider)
    {
        TimeOnly now = timeNowProvider.GetTimeNow();

        foreach (OpenPeriod openPeriod in OpenHoursToday)
        {
            if (now < openPeriod.OpenTime)
                return openPeriod.OpenTime - now;
            else if (now < openPeriod.ClosedTime)
                return TimeSpan.Zero;
        }

        TimeSpan timeRemainingToday = (new TimeOnly(23, 59) - now) + new TimeSpan(0, 1, 0);
        return this.OpenHoursTomorrow[0].OpenTime.ToTimeSpan() + timeRemainingToday;
    }
}
