namespace BankApplicationProject
{
    public class InvestmentAccount : Account
    {
        // Properties
        public Dictionary<string, decimal> Investments { get; set; }
        public decimal InterestRate { get; private set; }


        // Constructor
        public InvestmentAccount(string customerId, decimal interestRate = 0.07m) : base(customerId)
        {
            Investments = new Dictionary<string, decimal>();
            InterestRate = interestRate;
        }


        public bool InvestInStock(string stockSymbol, decimal amount)
        {
            if (amount > Balance)
            {
                    return false;
            }
            Balance -= amount;

            if (Investments.ContainsKey(stockSymbol))
            {
                Investments[stockSymbol] += amount;
            }
            else
            {
                Investments.Add(stockSymbol, amount);
            }

            SaveAccount();
            return true;

        }

        public decimal GetTotalInvestmentValue()
        {
            return Investments.Values.Sum() + Balance;
        }



    }
}