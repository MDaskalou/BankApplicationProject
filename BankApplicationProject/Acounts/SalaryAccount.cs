namespace BankApplicationProject;

public class SalaryAccount : Account
{
    public decimal MonthlyIncome { get; private set; }
    public bool AutomaticSavings { get; set; }
    public SalaryAccount(string customerId, decimal monthlyIncome) : base(customerId)
    {
        MonthlyIncome = monthlyIncome;
        AutomaticSavings = false;
    }

    public void ProcessMonthlyIncome(decimal monthlyIncome)
    {
        Deposit(MonthlyIncome);
        if (AutomaticSavings)
        {
            decimal savingsAmount = MonthlyIncome * 0.1m;

        }
    }

    public decimal GetBalance()
    {
        return Balance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Beloppet måste vara större än 0");
            return;
        }
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Beloppet måste vara större än 0.");
            return false;
        }
        if (amount > Balance)
        {
            Console.WriteLine($"Uttaget misslyckades. Kontroller att du har tillräkligt med pengar");
            return false;
        }

        Balance -= amount;
        Console.WriteLine($"Du har tagit ut {amount:C} kr. Ditt nya saldo är {Balance:C} kr");
        return true;

    }

    public void TransferMoney(SalaryAccount recipient, decimal amount)
    {
        if (Withdraw(amount))
        {
            recipient.Deposit(amount);
            Console.WriteLine($"Du har överfört {amount:C} kr till konto {recipient.AccountNumber}");
        }
    }
}