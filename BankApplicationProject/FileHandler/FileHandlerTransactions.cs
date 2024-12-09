using System.Text.Json;

namespace BankApplicationProject;

public class FileHandlerTransactions
{
    private const string TransactionsFilePath = @"C:\BankData\BankApplicationData.json";
    private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions
    {
        WriteIndented = true
    };

    public static List<Transaction> LoadTransactionsFromFile()
    {
        try
        {
            if (!File.Exists(TransactionsFilePath)) return new List<Transaction>();
            var jsonData = File.ReadAllText(TransactionsFilePath);
            return JsonSerializer.Deserialize<List<Transaction>>(jsonData, JsonSerializerOptions) ?? new List<Transaction>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading transactions: {ex.Message}");
            return new List<Transaction>();
        }
    }

    public static void WriteTransactionsToFile(Transaction transactionsData)
    {
        try
        {
            EnsureDirectoryExists(TransactionsFilePath);
            var jsonData = JsonSerializer.Serialize(transactionsData, JsonSerializerOptions);
            File.WriteAllText(TransactionsFilePath, jsonData);
            Console.WriteLine($"Transaktioner sparade i {Path.GetFullPath(TransactionsFilePath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving transactions: {ex.Message}");
            throw;
        }
    }

    private static void EnsureDirectoryExists(string filePath)
    {
        var directory = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
            Console.WriteLine($"Mappen {directory} skapades.");
        }
    }
}