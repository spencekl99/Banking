

namespace Banking.Tests.Unit;

public class BonusCalculatorTests
{
    private BonusCalculator _bonusCalculator;

    public BonusCalculatorTests()
    {
        _bonusCalculator = new BonusCalculator();
    }
    // "Accounts with a balance of 10,000 or more get a bonus"
    [Fact]
    public void AccountsUnderCutoffGetNoBonus()
    {
        // Write the Code You Wish You Had
       
        var balance = 4999.99M;
        var amountOfDeposit = 100M;

        decimal bonus =  _bonusCalculator.GetBonusForDepositOn(balance, amountOfDeposit);

        Assert.Equal(0, bonus);
    }

    [Fact]
    public void AcccountsAtMidlineGetSmallBonus()
    {
        var balance = 5000M;
        var amountToDeposit = 100M;

        var bonus = _bonusCalculator.GetBonusForDepositOn(balance, amountToDeposit);

        Assert.Equal(2.00M, bonus);
    }

    [Fact]
    public void AccountsAtOrAboveCutoffGetBonus()
    {
      
        var balance = 10000M;
        var amountOfDeposit = 100M;

        decimal bonus = _bonusCalculator.GetBonusForDepositOn(balance, amountOfDeposit);

        Assert.Equal(10M, bonus);
    }

    [Fact(Skip ="This will be your practice later")]
    public void PortionOfDepositEarnsBonus()
    {
      
        var balance = 9000M;
        var amountOfDeposit = 2000M;

        decimal bonus = _bonusCalculator.GetBonusForDepositOn(balance, amountOfDeposit);

        Assert.Equal(100M, bonus);
    }
}


public class DemoOfImplicitVsExplicitInterfaceStuff
{
    [Fact]
    public void Implicit()
    {
        ICalculateBonusesForAccounts bonusCalculator = new BonusCalculator();

        var amount = bonusCalculator.AccountDepositOf(1000, 10);
    
    }


}