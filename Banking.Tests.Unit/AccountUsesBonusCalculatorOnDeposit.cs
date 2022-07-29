

namespace Banking.Tests.Unit;

public class AccountUsesBonusCalculatorOnDeposit
{

    [Fact]
    public void ItDoesIt()
    {

        // Given
        var stubbedCalculator = new Mock<ICalculateBonusesForAccounts>();
        var account = new Account(stubbedCalculator.Object, new Mock<INotifyTheFed>().Object);
        stubbedCalculator.Setup(e => e.AccountDepositOf(account.GetBalance(), 110M)).Returns(42M);


        // When
        account.Deposit(110M);


        // Then
        Assert.Equal(5152M, account.GetBalance());
    }
}
