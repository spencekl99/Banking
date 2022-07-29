namespace Banking.Domain;

public interface INotifyTheFed
{
    void NotifyOfWithdrawal(Account account, decimal amountToWithdraw);
}