
namespace Banking.Domain;

public class StandardBusinessClock : IProvideTheBusinessClock
{
    private readonly ISystemTime _clock;

    public StandardBusinessClock(ISystemTime clock)
    {
        _clock = clock;
    }

    bool IProvideTheBusinessClock.IsDuringBusinessHours()
    {
        var now = _clock.GetCurrent();

        return now switch
        {
            var d when IsHoliday(d) => false,
            var d when IsWeekend(d) => false,
            _ => DuringOpenTimes(now)
        };
      
    }

    private static bool IsHoliday(DateTime now)
    {
        var holidays = new List<(int, int)> { (4, 7), (25, 12), (20, 4) };
        return holidays.Any(h => h == (now.Day, now.Month));
    }

    private bool DuringOpenTimes(DateTime now)
    {
        return now.Hour >= 9 && now.Hour < 17;
    }

    private  bool IsWeekend(DateTime now)
    {
        return now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday;
    }
}
