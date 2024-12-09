namespace BankApplicationProject;


// Transaction-klassen representerar en finansiell transaktion som utförs på ett bankkonto

public enum TransactionType
{
    Deposit,
    Withdraw,
    Transfer
}

public class Transaction
{
    public string TransactionId { get; }
    public DateTime Date { get; }
    public decimal Amount { get; }
    public TransactionType Type { get; }
    public string Description { get; }

    public string FromAccountNumber { get; }
    public string ToAccountNumber { get; set; }

    // Typ av transaktion, till exempel insättning, uttag eller överföring, baserat på TransactionType enum


    public Transaction(decimal amount, TransactionType type, string description, string
        fromAccountNumber, string toAccountNumber = null)
    {
        TransactionId = GenerateTransaktionId();
        Amount = amount;
        Description = description;
        Type = type;
        FromAccountNumber = fromAccountNumber;
        ToAccountNumber = toAccountNumber;
        Date = DateTime.Now;

    }

    private string GenerateTransaktionId()
    {
        return $"TRX {DateTime.Now:yyyyMMddHHmmss}{new Random().Next(1000, 9999)}";
    }

    private void HandleTransfer(Account sourceAccount, Account destinationAccount)
    {
        if (!sourceAccount.Withdraw(Amount))
        {
            throw new InvalidOperationException("Otillräkligt med pengar");
        }

        destinationAccount.Deposit(Amount);
    }

    public void Execute(Account sourceAccount, Account destinationAccount = null)
    {
        try
        {
            ValidateTransaction(sourceAccount, destinationAccount);

            switch (Type)
            {
                case TransactionType.Deposit:
                    HandleDeposit(sourceAccount);
                    break;
                case TransactionType.Withdraw:
                    HandleWithdraw(sourceAccount);
                    break;
                case TransactionType.Transfer:
                    if (destinationAccount == null)
                        throw new ArgumentNullException(nameof(destinationAccount),
                            "Destination account is required for tranfer.");
                    HandleTransfer(sourceAccount, destinationAccount);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            SaveTransactions();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    private void ValidateTransaction(Account sourceAccount, Account destinationAccount)
    {
        if(Amount <= 0)
            throw new ArgumentException("Summan måste vara positiv");
        if (sourceAccount == null)
            throw new ArgumentNullException(nameof(sourceAccount));

        if (sourceAccount is SavingsAccount savingsAccount)
        {
            ValidateSavingsAccountTransaction(savingsAccount);
        }
        else if (sourceAccount is InvestmentAccount)
        {
            ValidateInvestmentAccountTransaction(sourceAccount);
        }
    }

    private void ValidateSavingsAccountTransaction(SavingsAccount account)
    {
        if (Type == TransactionType.Withdraw || Type == TransactionType.Transfer)
        {

        }
    }

    private void ValidateInvestmentAccountTransaction(Account account)
    {

    }

    private void HandleDeposit(Account account)
    {
        account.Deposit(Amount);
    }

    private void HandleWithdraw(Account account)
    {
        if (!account.Withdraw(Amount));
        {
            throw new InvalidOperationException("Otillräckliga medel eller uttagsgräns överskriden");
        }
    }

    private void SaveTransactions()
    {
        FileHandlerTransactions.WriteTransactionsToFile(this);
    }

    private void LogTransactionErrors(Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    public string GetDetails()
    {
        var details =$"TransactionId: {TransactionId}," +
                     $" Date: {Date}, " +
                     $"Amount: {Amount}, " +
                     $"Type: {Type}" +
                     $"Description: {Description}" +
                     $"From Account: {FromAccountNumber}, ";

        if (Type == TransactionType.Transfer && !string.IsNullOrEmpty(ToAccountNumber))
        {
            details += $"To Account: {ToAccountNumber}, ";
        }
        return details;
    }
}


