namespace BankApplicationProject
{
    public class InvestmentAccount
    {
        // Properties
        public int AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public decimal Balance { get; private set; }
        public DateTime CreatedDate { get; private set; }

        // Constructor
        public InvestmentAccount(int accountNumber, string accountHolderName, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            Balance = initialBalance;
            CreatedDate = DateTime.Now;
        }

        // Methods
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Insättningen måste vara positiv", nameof(amount));
            }

            Balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Utdraget måste vara positiv", nameof(amount));
            }

            if (amount > Balance)
            {
                return false; // Insufficient funds
            }

            Balance -= amount;
            return true;
        }

        public decimal GetBalance()
        {
            return Balance;
        }
    }
}