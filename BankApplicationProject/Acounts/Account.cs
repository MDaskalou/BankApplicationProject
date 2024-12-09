using System.Text.Json;

namespace BankApplicationProject;

//Account klass representar bankkonto med grundläggande funktioner
public abstract class Account
{
    public string AccountNumber { get; protected set; }
    public decimal Balance { get; protected set; }
    public DateTime OpeningDate { get; protected set; }
    public string? CustomerId { get; protected set; }
    public string Type { get; set; }

    protected Account(string customerId)
    {
        AccountNumber = GenerateAccountNumber();
        Balance = 0;
        OpeningDate = DateTime.Now;
        CustomerId = customerId;
    }

    private string GenerateAccountNumber()
    {
        return $"ACC{new Random().Next(1000, 9999)}";
    }

    public virtual void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Insättningen måste vara positiv", nameof(amount));
        }

        Balance += amount;
        SaveAccount();
    }

    public virtual bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Utdraget måste vara positiv", nameof(amount));
        }

        if (amount > Balance)
        {
            return false;
        }

        Balance -= amount;
        SaveAccount();
        return true;
    }

    protected virtual void SaveAccount()
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "accounts.json");
        string accountJson = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        File.AppendAllText(filePath, accountJson + Environment.NewLine);
    }

}
