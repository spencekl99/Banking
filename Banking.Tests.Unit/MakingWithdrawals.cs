
namespace Banking.Tests.Unit;

public class MakingWithdrawals
{

    private Account _account;

  

    public MakingWithdrawals()
    {
        _account = new Account(new Mock<ICalculateBonusesForAccounts>().Object, new Mock<INotifyTheFed>().Object);
    }

   
    [Fact]
    public void WithdrawalsDecreaseTheBalance()
    {

  
        var openingBalance = _account.GetBalance();
        var amountToWithdraw = 100M;

        _account.Withdraw(amountToWithdraw);

        Assert.Equal(openingBalance - amountToWithdraw,
           _account.GetBalance());
    }

    [Fact]
    public void OverdraftDoesNotReduceBalance()
    {
        
        var openingBalance = _account.GetBalance();
        var amountToWithdraw = openingBalance + 1;

        try
        {
            _account.Withdraw(amountToWithdraw);
        }
        catch (OverdraftException)
        {

            // ignore 
        }
        finally
        {
            Assert.Equal(openingBalance, _account.GetBalance());
        }
    }

    [Fact]
    public void OverdraftThrows()
    {

      

        Assert.Throws<OverdraftException>(
            () =>  _account.Withdraw(_account.GetBalance() + 1)
        );


    }



    [Fact]
    public void ShouldBeAllowedToTakeTheEntireBalance()
    {
        // diud this blah
      

        _account.Withdraw(_account.GetBalance());

        Assert.Equal(0, _account.GetBalance());
    }

}
