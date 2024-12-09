using System.ComponentModel.Design;
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
        SalaryAccount? salaryAccount = null;
        SavingsAccount? savingsAccount = null;
        InvestmentAccount? investmentAccount = null;

        try
        {
            var existingCustomers = FileHandlerCustomer.LoadCustomersFromFile();

            do
            {
                WriteLine("Vänligen ange ditt namn (Både förnamn och efternamn)");
                fullName = ReadLine();

                if (string.IsNullOrWhiteSpace(fullName))
                {
                    WriteLine("Ogiltigt namn. Vänligen försök igen.");
                }
            } while (string.IsNullOrWhiteSpace(fullName));

            Console.WriteLine($"Namnet har registrerat: {fullName}");

            do
            {

                WriteLine("Vänligen ange adress");
                adress = ReadLine();

                if (string.IsNullOrWhiteSpace(adress))
                {
                    WriteLine("Ogiltig Adress. Vänligen försök igen.");
                }

            } while (string.IsNullOrWhiteSpace(adress));

            Console.WriteLine($"Adressen har registrerat: {adress}");

            do
            {
                WriteLine("Vänligen ange din email");
                email = ReadLine();

                if (string.IsNullOrWhiteSpace(email))
                {
                    WriteLine("Ogiltig email. Vänligen försök igen");
                    continue;
                }

            if (existingCustomers.Any(customer => customer.Email == email))
            {
                Console.WriteLine("Denna e-posten är redan registrerad.");
                return;
            }
            } while (string.IsNullOrWhiteSpace(email));

            Console.WriteLine($"Emailet har registrerat: {email}");

            do
            {
                Console.WriteLine("Vänligen ange ditt telefonnummer:");
                phoneNumber = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(phoneNumber) || !phoneNumber.All(char.IsDigit))
                {
                    Console.WriteLine("Ogiltigt nummer. Vänligen försök igen.");
                }
            } while (string.IsNullOrWhiteSpace(phoneNumber) || !phoneNumber.All(char.IsDigit));

            Console.WriteLine($"Telefonnummer registrerat: {phoneNumber}");

            do
            {
                Console.WriteLine("Vänligen ange ditt personnummer, 10 siffror:");
                personalNumber = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(personalNumber) || personalNumber.Length != 10 || !personalNumber.All(char.IsDigit) )
                {
                    Console.WriteLine("Ogiltigt personnummer. Vänligen försök igen.");
                    continue;
                }
                else if (existingCustomers.Any(customer => customer.PersonalNumber == personalNumber))
                {
                    Console.WriteLine("Detta personnummer är redan registrerat.");
                    return;
                }
            } while (string.IsNullOrWhiteSpace(personalNumber) || !personalNumber.All(char.IsDigit) || personalNumber.Length != 10);

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
            Console.ReadKey();
            Console.Clear();


            Console.WriteLine("Nu ska vi regristrera dina konton");

            bool isValidInput = false;

            do
            {

            Console.Write("Vill du skapa ett lönekonto(Ja/Nej) ");
            var response = Console.ReadLine().ToLower();

            if (response == "ja")
            {
                Console.Write("Hur mycket pengar vill du sätta in?: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal initalDeposit) && initalDeposit > 0)
                {
                   salaryAccount = new SalaryAccount(Guid.NewGuid().ToString(), initalDeposit);
                    Console.WriteLine($"Lönekonto är regristrerad och {initalDeposit} kr är insatt i ditt konto");

                    Console.Write(" Vilken månadslön har du?");
                    if (decimal.TryParse(Console.ReadLine(), out decimal monthlyIncome) && monthlyIncome > 0)
                    {
                        salaryAccount.ProcessMonthlyIncome(monthlyIncome);
                        Console.WriteLine($"Din månadslön {monthlyIncome} kommer nu sättas in i ditt konto varje månad");

                    }
                    else
                    {
                        Console.WriteLine("Ogiltig månadsbelopp. Försök igen");
                        continue;
                    }

                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Ogiltig belopp.Försök igen");
                    return;
                }
            }
            else if (response == "nej")
            {
                Console.WriteLine("Lönekonto skapas inte");
                isValidInput = true;
            }
            else
            {
                Console.WriteLine("Ogiltig svar. Ange Ja eller Nej");
            }

            } while (!isValidInput);



            isValidInput = false;
            do
            {

            Console.Write("Vill du skapa ett sparkonto? (ja/nej)");
            var response = Console.ReadLine().ToLower();

            if (response == "ja")
            {
                Console.Write("Hur mycket pengar vill du sätta in?: ");
                Console.ReadLine();

                if (decimal.TryParse(Console.ReadLine(), out decimal initalDeposit) && initalDeposit > 0)
                {
                    savingsAccount = new SavingsAccount(Guid.NewGuid().ToString(), 0.02m);
                    Console.WriteLine($"Sparkonto är regristrerad och beloppet {initalDeposit} kr är insätt i ditt konto ");
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Ogiltigt belopp. Försök igen.");
                }
            }
            else if (response == "nej")
            {
                Console.WriteLine($"Sparkonto har ej skapats");
                isValidInput = true;
            }
            else
            {
                Console.WriteLine("Ogiltig svar. Ange Ja eller Nej");
            }

            } while (!isValidInput);

            isValidInput = false;
            do
            {

            Console.Write("Vill du skapa ett investeringskonto? (ja/nej)");
            var response = Console.ReadLine().ToLower();

            if (response == "ja")
            {
                Console.WriteLine("Hur mycket pengar vill du sätta in i ditt invenstringskonto?");
                if (decimal.TryParse(Console.ReadLine(), out decimal initalDeposit) && initalDeposit > 0)
                {
                    investmentAccount = new InvestmentAccount(Guid.NewGuid().ToString(), 0.07m);

                    Console.WriteLine($"Investeringskonto registrerat, och beloppet: {initalDeposit} kr är insätt i ditt konto.");
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Ogiltig belopp. Försök igen.");
                }
            }
            else if (response == "nej")
            {
                Console.WriteLine("Invensteringskonto är inte regrstrerad");
            }
            else
            {
                Console.WriteLine("Ogiltigt svar. Välj mellan ja eller nej");
            }


            } while (!isValidInput);


            var newCustomer = new Customer(Guid.NewGuid().ToString(), fullName, adress, email, phoneNumber, personalNumber, password);
            {
                newCustomer.SalaryAccount = salaryAccount;
                newCustomer.SavingsAccount = savingsAccount;
                newCustomer.InvestmentAccount = investmentAccount;
            }



            FileHandlerCustomer.AddCustomerToFile(newCustomer);


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