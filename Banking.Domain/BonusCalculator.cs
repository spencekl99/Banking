namespace Banking.Domain;

public class BonusCalculator : ICalculateBonusesForAccounts
{
   

    public decimal GetBonusForDepositOn(decimal balance, decimal amountOfDeposit)
    {
        return balance switch
        {
            < 5_000 => 0,
            < 10_000 => amountOfDeposit * .02M,
            _ =>  amountOfDeposit * 0.1M
        };
    }

    decimal ICalculateBonusesForAccounts.AccountDepositOf(decimal balance, decimal amountToDeposit)
    {
        // other things might have to happen.
        return GetBonusForDepositOn(balance, amountToDeposit);
    }
}