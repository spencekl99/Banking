

namespace Banking.Tests.Unit;

public class NegativeNumbersNotAllowedForDepositsOrWithdrawals
{

    [Fact]
    public void NegativesNotAllowedForDeposit()
    {
        var account = new Account(new Mock<ICalculateBonusesForAccounts>().Object, new Mock<INotifyTheFed>().Object);
        var openingBalance = account.GetBalance();

        Assert.Throws<NegativeValuesNotAllowedException>(() => account.Deposit(-1000));

        Assert.Equal(openingBalance, account.GetBalance());
    }
}
