
namespace Banking.Domain;

public class SystemTime : ISystemTime
{
    public DateTime GetCurrent()
    {
        return DateTime.Now; // THE ONY PLACE YOU ARE ALLOWED TO TOUCH THIS THING.
    }
}