
using Banking.Domain;

namespace Banking.Tests.Unit;

public class BusinessClockDrivenBonusCalculatTests
{

    [Fact]
    public void DuringBusinessHoursBonusIsGiven()
    {
        var stubbedClock = new Mock<IProvideTheBusinessClock>();
        ICalculateBonusesForAccounts bonusCalculator = new BusinessClockDrivenBonusCalculator(stubbedClock.Object);
        stubbedClock.Setup(c => c.IsDuringBusinessHours()).Returns(true);

        var bonus = bonusCalculator.AccountDepositOf(10000, 100);

        Assert.Equal(10M, bonus);
    }

    [Fact]
    public void OutsideBusinessHoursBonusIsNotGiven()
    {
        var stubbedClock = new Mock<IProvideTheBusinessClock>();
        ICalculateBonusesForAccounts bonusCalculator = new BusinessClockDrivenBonusCalculator(stubbedClock.Object);
        stubbedClock.Setup(c => c.IsDuringBusinessHours()).Returns(false);

        var bonus = bonusCalculator.AccountDepositOf(10000, 100);

        Assert.Equal(0, bonus);
    }

}

