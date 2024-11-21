using System.Text.Json;

namespace BankApplicationProject;

public static class FileHandler
{
    private const string AccountsFilePath = "accounts.json";
    private const string TransactionsFilePath = "transactions.json";
    private const string CustomersFilePath = "customers.json";

    private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };


    public static List<Customer> LoadCustomersFromFile()
    {
        if (!File.Exists(CustomersFilePath))
            return new List<Customer>();

        var jsonData = File.ReadAllText(CustomersFilePath);
        return JsonSerializer.Deserialize<List<Customer>>(jsonData) ?? new List<Customer>();
    }
    // Spara kunder till JSON
    private static void WriteCustomersToFile(List<Customer> customersData)
    {
        var jsonData = JsonSerializer.Serialize(customersData, JsonSerializerOptions);
        File.WriteAllText(CustomersFilePath, jsonData);
    }

    public static void AddCustomerToFile(Customer newCustomer)
    {
        var customersData = LoadCustomersFromFile();
        customersData.Add(newCustomer);
        WriteCustomersToFile(customersData);
    }



    //Metod för att ladda konton från Json
    public static List<Account> LoadAcountsFromFile()
    {
        if (!File.Exists(AccountsFilePath)) return new List<Account>();
        var jsonData = File.ReadAllText(AccountsFilePath);
        return JsonSerializer.Deserialize<List<Account>>(jsonData) ?? new List<Account>();
    }

    //Metod för att skriva konton till Jsonfil
    private static void WriteAccountsToFile(List<Account> accountsData)
    {
        var jsonData = JsonSerializer.Serialize(accountsData, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(AccountsFilePath, jsonData);
    }

    //Metod för att ladda transaktioner från en jsonfil
    private static List<Transaction> LoadTransactionsFromFile()
    {
        if (!File.Exists(TransactionsFilePath)) return new List<Transaction>();
        var jsonData = File.ReadAllText(TransactionsFilePath);
        return JsonSerializer.Deserialize<List<Transaction>>(jsonData) ?? new List<Transaction>();
    }

    // Metod för att skriva transaktioner till en JSON-fil
    private static void WriteTransactionsToFile(List<Transaction> transactionsData)
    {
        var jsonData = JsonSerializer.Serialize(transactionsData, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(TransactionsFilePath, jsonData);
    }

    // Metod för att lägga till en transaktion till filen
    public static void AppendTransactionToFile(Transaction transaction)
    {
        var transactionsData = LoadTransactionsFromFile();
        transactionsData.Add(transaction);
        WriteTransactionsToFile(transactionsData);
    }

    //Metod fö att Ladda konto från fil
    public static List<Account> LoadAccountsFromFile()
    {
        if (!File.Exists(AccountsFilePath))
            return new List<Account>(); // Returnerar en tom lista om filen inte finns

        var jsonData = File.ReadAllText(AccountsFilePath); // Läser all JSON-data från filen
        return JsonSerializer.Deserialize<List<Account>>(jsonData) ?? new List<Account>();
    }

    // Metod för att lägga till ett konto till filen
    public static void SaveAccountToFile(Account account)
    {
        var accountsData = LoadAccountsFromFile();
        accountsData.Add(account);
        WriteAccountsToFile(accountsData);
    }

    //Metod för att att spara ensklid transaktion
    public static void SaveTransactionsToFile(Transaction transaction)
    {
        var transactionsData = LoadTransactionsFromFile();
        transactionsData.Add(transaction);
        WriteTransactionsToFile(transactionsData);
    }

}

