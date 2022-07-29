namespace Banking.Domain;

public interface ICalculateBonusesForAccounts
{
    decimal AccountDepositOf(decimal balance, decimal amountToDeposit);
}