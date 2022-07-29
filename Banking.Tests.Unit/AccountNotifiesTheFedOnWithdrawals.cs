
namespace Banking.Tests.Unit;

public class AccountNotifiesTheFedOnWithdrawals
{

    [Fact]
    public void TheFedIsNotified()
    {
        // Given
        var mockedFed = new Mock<INotifyTheFed>();
        var account = new Account(new Mock<ICalculateBonusesForAccounts>().Object, mockedFed.Object);
        var amountToWithdraw = 127.23M;


        // When
        account.Withdraw(amountToWithdraw);

        
        // Then
        mockedFed.Verify(f => f.NotifyOfWithdrawal(account, amountToWithdraw),Times.Once);
    }
}
