
namespace Banking.Tests.Unit;

public class StandardBusinessClockTests
{
    // During business days (9-5 local time)

    [Fact]
    public void At900WeAreOpen()
    {
        //var stubbedClock = new Mock<ISystemTime>();
        var stubbedClock = Mock.Of<ISystemTime>();
        IProvideTheBusinessClock clock = new StandardBusinessClock(stubbedClock);
        Mock.Get(stubbedClock).Setup(c => c.GetCurrent()).Returns(new DateTime(2022, 7, 29, 9, 00, 00));


        Assert.True(clock.IsDuringBusinessHours());
    }
    [Fact]
    public void At500WeAreClosed()
    {
        var stubbedClock = new Mock<ISystemTime>();
        IProvideTheBusinessClock clock = new StandardBusinessClock(stubbedClock.Object);
        stubbedClock.Setup(c => c.GetCurrent()).Returns( new DateTime(2022, 7, 29, 17, 00, 00) );


        Assert.False(clock.IsDuringBusinessHours());
    }

    // We are closed on the following days:
    // Weekends (Saturday and Sunday)
    [Theory]
    [InlineData(7,30,2022)]
    [InlineData(7,31,2022)]
    public void ClosedOnWeekends(int day, int month, int year)
    {
        var stubbedClock = new Mock<ISystemTime>();
        IProvideTheBusinessClock clock = new StandardBusinessClock(stubbedClock.Object);
        stubbedClock.Setup(c => c.GetCurrent()).Returns(new DateTime(year, day, month, 14, 00, 00));

        Assert.False(clock.IsDuringBusinessHours());
    }
    // 7/4 - Fourth of July
    // 12/25 - Christmas
    // 4/20 - Jeff's Birthday

    [Theory]
    [InlineData(4, 7)]
    [InlineData(25,12)]
    [InlineData(20,4)]
    
    public void ClosedOnHolidays(int day, int month)
    {
        var stubbedClock = new Mock<ISystemTime>();
        IProvideTheBusinessClock clock = new StandardBusinessClock(stubbedClock.Object);
       // 
        stubbedClock.Setup(c => c.GetCurrent()).Returns(new DateTime(2022, month, day, 14, 00, 00));

        Assert.False(clock.IsDuringBusinessHours());
    }

}
