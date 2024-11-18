namespace BankApplicationProject;


// Transaction-klassen representerar en finansiell transaktion som utförs på ett bankkonto

public class Transaction
{
    public string TransactionID { get; set; }
    public DateTime Date{ get; set; }
    public decimal Amount { get; set; }

    // Typ av transaktion, till exempel insättning, uttag eller överföring, baserat på TransactionType enum

    public TransactionType TransactionType { get; set; }
    public string Description { get; set; }

    public Transaction(string transactionID, DateTime date, decimal amount, TransactionType transactionType, string description)
    {
        TransactionID = transactionID;
        Amount = amount;
        Description = description;
        TransactionType = transactionType;
        Date = date;
    }


    // Metod för att utföra transaktionen; just nu är den tom och kan fyllas med logik för att hantera transaktionen
    public void Execute(Account account)
    {
        try
        {
            if (TransactionType == TransactionType.Deposit)
            {
                account.Balance += Amount;
            }
             else if (TransactionType == TransactionType.Withdraw)
             {
                 if (Amount <= account.Balance)
                 {
                     account.Balance -= Amount;
                 }
                 else
                 {
                     throw new InvalidOperationException("Not enough money");
                 }
             }
            else if (TransactionType == TransactionType.Transfer)
            {
                throw new NotImplementedException("Not implemented");
            }

            account.GetTransactions().Add(this);
            FileHandler.SaveTransactionsToFile(this);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }

    //private void AppendTransactionToFile(Transaction transaction)
    //{
      //  string filePath = "transaction_log.txt";
        //string transactionInfo = $"{transaction.Date}\t{transaction.Amount}\t{transaction.TransactionType}";
        //File.AppendAllText(filePath, transactionInfo + Environment.NewLine);
        //throw new NotImplementedException();
    //}

    // Metod för att hämta en detaljerad beskrivning av transaktionen som en sträng

    public string GetDetails()
    {
        return $"Transaction ID {TransactionID} Date {Date} Amount {Amount} Description {Description}";
    }

    //private void SaveTransaction(Transaction transaction)
    //{
     //   AppendTransactionToFile(transaction);
    //}


}
public enum TransactionType
{
    Deposit,
    Withdraw,
    Transfer
}


