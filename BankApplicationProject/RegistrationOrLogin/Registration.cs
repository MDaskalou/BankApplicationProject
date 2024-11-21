using static System.Console;

namespace BankApplicationProject.RegistrationOrLogin;

public class Registration
{
    public static void RegisterNewCostumer()
    {
        string? fullName;
        string? adress;
        string? email;
        string? phoneNumber;
        string? personalNumber;
        string? password = null;
        string? confirmationPassword = null;

        bool isValidInfo = false;

        try
        {
            var existingCustomers = FileHandler.LoadCustomersFromFile();

            do
            {
                WriteLine("Vänligen ange ditt namn (Både förnamn och efternamn)");
                fullName = ReadLine();
                isValidInfo = !string.IsNullOrWhiteSpace(fullName);

                if (!isValidInfo)
                {
                    WriteLine("Ogiltigt namn. Vänligen försök igen.");
                }
            } while (!isValidInfo);

            isValidInfo = false;

            Console.WriteLine($"Namnet har registrerat: {fullName}");


            do
            {

                WriteLine("Vänligen ange adress");
                adress = ReadLine();
                isValidInfo = !string.IsNullOrWhiteSpace(adress);

                if (!isValidInfo)
                {
                    WriteLine("Ogiltig Adress. Vänligen försök igen.");
                }

            } while (!isValidInfo);

            isValidInfo = false;

            Console.WriteLine($"Adressen har registrerat: {adress}");

            do
            {
                WriteLine("Vänligen ange din email");
                email = ReadLine();
                isValidInfo = !string.IsNullOrWhiteSpace(email) && IsValidEmail(email);

                if (!isValidInfo)
                {
                    WriteLine("Ogiltig email. Vänligen försök igen");
                }


            if (existingCustomers.Any(customer => customer.Email == email))
            {
                Console.WriteLine("Denna e-posten är redan registrerad.");
                return;
            }
            } while (!isValidInfo);

            Console.WriteLine($"Emailet har registrerat: {email}");

            do
            {
                Console.WriteLine("Vänligen ange ditt telefonnummer:");
                phoneNumber = Console.ReadLine();

                isValidInfo = !string.IsNullOrWhiteSpace(phoneNumber) && phoneNumber.All(char.IsDigit);

                if (!isValidInfo)
                {
                    Console.WriteLine("Ogiltigt nummer. Vänligen försök igen.");
                }
            } while (!isValidInfo);

            Console.WriteLine($"Telefonnummer registrerat: {phoneNumber}");

            do
            {
                Console.WriteLine("Vänligen ange ditt personnummer, 10 siffror:");
                personalNumber = Console.ReadLine();

                isValidInfo = !string.IsNullOrWhiteSpace(personalNumber) && personalNumber.Length == 10 &&
                              personalNumber.All(char.IsDigit);

                if (!isValidInfo)
                {
                    Console.WriteLine("Ogiltigt personnummer. Vänligen försök igen.");
                }
                else if (existingCustomers.Any(customer => customer.PersonalNumber == personalNumber))
                {
                    Console.WriteLine("Detta personnummer är redan registrerat.");
                    return;
                }
            } while (!isValidInfo);

            do
            {
                Console.WriteLine("Skriv ditt nya lösenord (minst 8 tecken, innehållande bokstäver, siffror och specialtecken):");
                password = Console.ReadLine();

                if (!IsStrongPassword(password))
                {
                    Console.WriteLine("Lösenordet är inte starkt nog. ");
                    Console.WriteLine(" till att det är minst 8 tecken långt och innehåller bokstäver, siffror och specialtecken.");
                    continue;
                }

                Console.WriteLine("Bekräfta ditt lösenord igen");
                confirmationPassword = Console.ReadLine();

                if (password != confirmationPassword)
                {
                    Console.WriteLine("Lösenorden matchar inte. Vänligen försök igen.");
                }

            } while (confirmationPassword == null || password != confirmationPassword);

            Console.WriteLine("Lösenordet är bekräftat.");

            var newCustomer = new Customer(Guid.NewGuid().ToString(), fullName, adress, email, phoneNumber, personalNumber, password, confirmationPassword);

            FileHandler.AddCustomerToFile(newCustomer);
        }
        catch (Exception ex)
        {
            WriteLine($"Ett oväntat fel uppstod: {ex.Message}");
            throw;
        }
    }
    private static bool IsStrongPassword(string? password)
    {
        if (string.IsNullOrWhiteSpace(password))
            return false;

        bool hasLetterOrDigit = password.Any(char.IsLetterOrDigit);
        bool hasSpecialCharacter = password.Any(ch => !char.IsLetterOrDigit(ch));
        bool hasValidLength = password.Length >= 8;

        return hasLetterOrDigit && hasSpecialCharacter && hasValidLength;
    }

    private static  bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

}