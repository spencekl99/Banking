using Banking.Domain;

namespace BankingKioskPoc
{
    public partial class Form1 : Form, INotifyTheFed
    {

        private Account _account;
        public Form1()
        {
            InitializeComponent();
            // "Composition Root"
            _account = new Account(new BusinessClockDrivenBonusCalculator(new StandardBusinessClock(new SystemTime())), this);

            this.Text = _account.GetBalance().ToString("c");
        }

        public void NotifyOfWithdrawal(Account account, decimal amountToWithdraw)
        {
            MessageBox.Show($"Notifying the fed of withdrawal of {amountToWithdraw:c}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoTransaction(_account.Deposit);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoTransaction(_account.Withdraw);
        }

        private void DoTransaction(Action<decimal> op)
        {
            try
            {
                var amount = amountBox.Text;


                //_account.Withdraw(decimal.Parse(amount));
                op(decimal.Parse(amount));

                this.Text = _account.GetBalance().ToString("c");

              
            }
            catch(NegativeValuesNotAllowedException)
            {
                MessageBox.Show("What are you, a haxx0r!!! The police have been called!");
            }
            catch (FormatException)
            {

                MessageBox.Show("Enter a number, dummy");
            }
            catch( OverdraftException)
            {
                MessageBox.Show("You don't have enough money. Get a job, fool.");
            }
            finally
            {
                amountBox.SelectAll();
                amountBox.Focus();
            }
        }
    }
}