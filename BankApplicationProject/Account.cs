using System.Text.Json;

namespace BankApplicationProject;

//Account klass representar bankkonto med grundläggande funktioner
public class Account
{
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
    public AccountType Type { get; set; }
    public DateTime OpeningDate { get; set; }
    public string CustomerId { get; set; }


    //Metod för att sätta in pengar
    public void Deposit(decimal amount)
    {
        var balance = Balance +- amount;
        SaveAccount();
    }

    //metod för att kunna ta ut pengar

    public void Withdraw(decimal amount)
    {
        //kontrollera om det finns tillräkligt med pengar
        if (amount <= Balance)
        {
            Balance -= amount;
            SaveAccount();
        }
        else
        {
            throw new InvalidOperationException("Insufficient balance");
        }
    }
    // Metod för att hämta transaktioner kopplade till kontot
    public List<Transaction> GetTransactions()
    {
        return new List<Transaction>();
    }

    private void SaveAccount()
    {
        SaveAccountToFile(this);
    }

    private void SaveAccountToFile(Account account)
    {
        string filePath = "accounts_log.json";
        string accountJson = JsonSerializer.Serialize(account, new JsonSerializerOptions { WriteIndented = true });
        File.AppendAllText(filePath, accountJson + Environment.NewLine);
        //throw new NotImplementedException();
    }
}
public enum AccountType
{
    Savings,
    Checking,
    Business
}