using BankApplicationProject.UserMenu;

namespace BankApplicationProject.RegistrationOrLogin;

public class Login
{

    public static void LoginToBank()
    {

        try
        {
            var customers = FileHandlerCustomer.LoadCustomersFromFile();

            string? personalNumber;
            string? password;
            bool isLoggedIn = false;
            Customer? matchingCustomer = null;

            Console.WriteLine("Välkommen till Mikaels Bank");

            do
            {

                Console.WriteLine("Vänligen skriv ditt personnummer.");
                personalNumber = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(personalNumber) || personalNumber.Length != 10 ||
                    !personalNumber.All(char.IsDigit))
                {
                    Console.WriteLine("Felaktig personnummer. Försök igen.");
                    continue;
                }

                matchingCustomer = customers.FirstOrDefault(customer => customer.PersonalNumber == personalNumber);

                if (matchingCustomer == null)
                {
                    Console.WriteLine("Personnummer är inte regristrerad.Försök igen.");
                }
            } while (isLoggedIn);


            do
                {
                    Console.WriteLine("vänligen skriv ditt lösenord.");
                    password = Console.ReadLine();

                    if(matchingCustomer.Password == password)
                    {
                        Console.WriteLine($"Inloggning lyckades! Välkommen, {matchingCustomer.FullName}!");
                        isLoggedIn = true;
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Felaktigt lösenord. Försök igen.");
                    }
                } while (isLoggedIn);

                LoggedInMenu.LoggedInMenuOptions(matchingCustomer);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ett fel inträffade under inloggning: {ex.Message}");
        }

    }

}