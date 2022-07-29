

namespace Banking.Tests.Unit;

public class BonusCalculatorDummy : ICalculateBonusesForAccounts
{
    public decimal AccountDepositOf(decimal balance, decimal amountToDeposit)
    {
        return 0;
    }
}

public class StubbedCalculator : ICalculateBonusesForAccounts
{
    public decimal AccountDepositOf(decimal balance, decimal amountToDeposit)
    {
        return balance == 5000M & amountToDeposit == 110M ? 42 : 0;
    }
}

public class DummyFedNotifier : INotifyTheFed
{
    public void NotifyOfWithdrawal(Account account, decimal amountToWithdraw)
    {
        // nothing.
    }
}