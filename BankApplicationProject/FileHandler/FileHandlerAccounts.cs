using System.Text.Json;

namespace BankApplicationProject;

public class FileHandlerAccounts
{
    private const string AccountsFilePath = "data/accounts.json";
    private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions
    {
        WriteIndented = true
    };

    public static List<Account> LoadAccountsFromFile()
    {
        try
        {
            if (!File.Exists(AccountsFilePath)) return new List<Account>();
            var jsonData = File.ReadAllText(AccountsFilePath);
            return JsonSerializer.Deserialize<List<Account>>(jsonData, JsonSerializerOptions) ?? new List<Account>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading accounts: {ex.Message}");
            return new List<Account>();
        }
    }

    public static void WriteAccountsToFile(List<Account> accountsData)
    {
        try
        {
            EnsureDirectoryExists(AccountsFilePath);
            var jsonData = JsonSerializer.Serialize(accountsData, JsonSerializerOptions);
            File.WriteAllText(AccountsFilePath, jsonData);
            Console.WriteLine($"Konton sparade i {Path.GetFullPath(AccountsFilePath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving accounts: {ex.Message}");
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