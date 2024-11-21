using System.Text.Json;

namespace BankApplicationProject;

public class FileHandlerCustomer
{
    private const string CustomersFilePath = "data/customers.json";
    private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions
    {
        WriteIndented = true
    };

    public static List<Customer> LoadCustomersFromFile()
    {
        try
        {
            if (!File.Exists(CustomersFilePath)) return new List<Customer>();
            var jsonData = File.ReadAllText(CustomersFilePath);
            return JsonSerializer.Deserialize<List<Customer>>(jsonData, JsonSerializerOptions) ?? new List<Customer>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading customers: {ex.Message}");
            return new List<Customer>();
        }
    }

    public static void WriteCustomersToFile(List<Customer> customersData)
    {
        try
        {
            Console.WriteLine($"Serializing följande data : {JsonSerializer.Serialize(customersData, JsonSerializerOptions)}");
            EnsureDirectoryExists(CustomersFilePath);
            var jsonData = JsonSerializer.Serialize(customersData, JsonSerializerOptions);
            File.WriteAllText(CustomersFilePath, jsonData);
            Console.WriteLine($"Kunder sparade i {Path.GetFullPath(CustomersFilePath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving customers: {ex.Message}");
            throw;
        }
    }

    public static void AddCustomerToFile(Customer newCustomer)
    {
        try
        {
            var customer = LoadCustomersFromFile();

            Console.WriteLine($"Antal Kunder före tillägg: {customer.Count}");
            customer.Add(newCustomer);
            Console.WriteLine($"Antal kunder efter tillägg: {customer.Count}");

            WriteCustomersToFile(customer);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving customers: {ex.Message}");
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