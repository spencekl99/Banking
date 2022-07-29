



namespace Banking.Tests.Unit;

public class BrandNewAccounts
{

    [Fact]
    public void NewAccountsHaveCorrectBalance()
    {
        // Given I have a new account
        var account = new Account(new BonusCalculatorDummy(), new Mock<INotifyTheFed>().Object);
        // When I ask it for the balance
        decimal balance = account.GetBalance();
        // Then it should be 5K
        Assert.Equal(5000M, balance);
    }

   
}

