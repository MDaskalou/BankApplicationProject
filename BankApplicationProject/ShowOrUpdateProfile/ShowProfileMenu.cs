namespace BankApplicationProject.ShowOrUpdateProfile;

public class ShowProfileMenu
{
    public static void ShowProfileInfo(string? customerId)
    {

        try
        {
            var customers = FileHandlerCustomer.LoadCustomersFromFile();


            var customer = customers.FirstOrDefault(customer => customer.CustomerId == customerId);

            if (customer == null)
            {
                Console.WriteLine("Kund hittades inte.");
                return;
            }

            Console.WriteLine("====Kundinformation====");
            Console.WriteLine($"Kund ID: {customer.CustomerId}");
            Console.WriteLine($"Namn: {customer.FullName}");
            Console.WriteLine($"Adress: {customer.Address}");
            Console.WriteLine($"E-post: {customer.Email}");
            Console.WriteLine($"Telefon: {customer.PhoneNumber}");
            Console.WriteLine($"Personnummer: {customer.PersonalNumber}");

            Console.WriteLine("====KontoInformation====");
            DisplayAccountsDetails(customer);


            DisplayAccounts(customerId);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Något gick fel: {ex.Message}");
            throw;
        }
    }


    private static void DisplayAccountsDetails(Customer customer)
    {

        try
        {
            if (customer.SalaryAccount != null)
            {
                Console.WriteLine("====LönekontoInformation====");
                Console.WriteLine($"Saldo: {customer.SalaryAccount.Balance:C}");
            }
            else
            {
                Console.WriteLine("Du har inget lönekonto");
            }

            if (customer.SavingsAccount != null)
            {
                Console.WriteLine("====SparKontoInformation====");
                Console.WriteLine($"Saldo: {customer.SavingsAccount.Balance:C}");
            }
            else
            {
                Console.WriteLine("Du har inget sparkonto");
            }

            if (customer.InvestmentAccount != null)
            {
                Console.WriteLine("====Invensteringskonto Information====");
                Console.WriteLine($"Saldo: {customer.InvestmentAccount.Balance:C}");
            }
            else
            {
                Console.WriteLine("Du har inget Invensteringskonto");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }

    }

    private static void DisplayAccounts(string? customerId)
    {
        try
        {
            var accounts = FileHandlerAccounts.LoadAccountsFromFile()
                .Where(account => account.CustomerId == customerId).ToList();

            Console.WriteLine($"Laddade konton för kund {customerId}: {accounts.Count()}");

            if (!accounts.Any())
            {
                Console.WriteLine("Inga konton hittades");
                return;
            }

            foreach (var account in accounts)
            {
                Console.WriteLine("---- Konto Detaljer ----");
                Console.WriteLine($"Kontonummer: {account.AccountNumber}");
                Console.WriteLine($"Kontotyp: {account.Type}");
                Console.WriteLine($"Saldo: {account.Balance:C}");
                Console.WriteLine($"Öppningsdatum: {account.OpeningDate:dd/MM/yyyy}");
                Console.WriteLine("------------------------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

}