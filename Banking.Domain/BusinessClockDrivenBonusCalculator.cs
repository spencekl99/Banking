namespace Banking.Domain;

public class BusinessClockDrivenBonusCalculator : ICalculateBonusesForAccounts
{
    private readonly IProvideTheBusinessClock _businessClock;

    public BusinessClockDrivenBonusCalculator(IProvideTheBusinessClock businessClock)
    {
        _businessClock = businessClock;
    }

    decimal ICalculateBonusesForAccounts.AccountDepositOf(decimal balance, decimal amountToDeposit)
    {
        if (_businessClock.IsDuringBusinessHours())
        {
            return balance switch
            {
                < 5_000 => 0,
                < 10_000 => amountToDeposit * .02M,
                _ => amountToDeposit * 0.1M
            };
        }
        else
        {
            return 0;
        }
    }

    protected virtual bool IsDuringBusinessHour()
    {
        return DateTime.Now.Hour >= 9 && DateTime.Now.Hour < 17;
    }
}
