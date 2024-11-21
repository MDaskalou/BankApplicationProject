using static System.Console;
using static BankApplicationProject.FileHandlerCustomer;


namespace BankApplicationProject.RegistrationOrLogin;

public class Registration
{
  public static void RegisterNewCostumer()
  {

    string? fullName, address, email, phoneNumber, personalNumber, password, customerId;

    try
    {
      List<Customer> existingCustomers = FileHandlerCustomer.LoadCustomersFromFile();

      Console.WriteLine("Existerande kunder vid regristrering;");
      foreach (var customer in existingCustomers)
      {
          Console.WriteLine($"Personnummer{customer.PersonalNumber},Namn: {customer.FullName}, Adress: {customer.Address}, Telefon: {customer.PhoneNumber}," +
                            $" Email: {customer.Email}, Telefon: {customer.PhoneNumber}, ID: {customer.CustomerId} ");

      }

      fullName = PromptForInput("Vänligen ange ditt namn (Både förnamn och efternamn):");
      address = PromptForInput("Vänligen ange adress:");
      email = PromptForInput("Vänligen ange din email:", input => IsValidEmail(input));
      phoneNumber = PromptForInput("Vänligen ange ditt telefonnummer:", input => input.All(char.IsDigit));
      personalNumber = PromptForInput("Vänligen ange ditt personnummer (10 siffror):",
        input => input.Length == 10 && input.All(char.IsDigit));

      if (existingCustomers.Any(c => c.PersonalNumber == personalNumber))
      {
        Console.WriteLine("Detta personnummer är redan registrerat.");
        return;
      }

      password = PromptForPassword("Skriv ditt nya lösenord (minst 8 tecken");
      customerId = Customer.GenerateCustomerIdNumber(existingCustomers);

      var newCustomer = new Customer(customerId, fullName, address, email, phoneNumber, personalNumber, password);
      FileHandlerCustomer.AddCustomerToFile(newCustomer);

      Console.WriteLine($"Kund {fullName} är regristrerad med kund ID {customerId}");

    }
    catch (Exception ex)
    {
      WriteLine($"Ett oväntat fel {ex.Message}");
    }
  }
    private static string PromptForInput(string message, Func<string, bool>? validation = null)
    {
      string? input;
      do
      {
        Console.Write(message);
        input = Console.ReadLine() ?? "";

      } while (validation != null && !validation(input));

      return input;
    }

    private static string PromptForPassword(string message)
    {
      string password, confirmationPassword;
      do
      {
        Console.WriteLine(message);
        password = Console.ReadLine() ?? "";
        Console.WriteLine("Bekräfta lösenordet:");
        confirmationPassword = Console.ReadLine() ?? "";

        if (password != confirmationPassword)
          Console.WriteLine("Lösenorden matchar inte. Försök igen.");
      } while (password != confirmationPassword || password.Length < 8);

      return password;
    }

    private static bool IsValidEmail(string email)
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

    //bool isValidInfo = false;

    // try
    //{
//
    //          List<Customer> existingCustomers = FileHandler.LoadCustomersFromFile();
//
    //          do
    //        {
    //          WriteLine("Vänligen ange ditt namn (Både förnamn och efternamn)");
    //        fullName = ReadLine();
    //      isValidInfo = !string.IsNullOrWhiteSpace(fullName);
//
    //              if (!isValidInfo)
    //            {
    //              WriteLine("Ogiltigt namn. Vänligen försök igen.");
    //        }
    //  } while (!isValidInfo);
//
    //          isValidInfo = false;
//
    //          Console.WriteLine($"Namnet har registrerat: {fullName}");
//
//
    //          do
    //        {
//
    //              WriteLine("Vänligen ange adress");
    //            address = ReadLine();
    //          isValidInfo = !string.IsNullOrWhiteSpace(address);
//
    //              if (!isValidInfo)
    //            {
    //              WriteLine("Ogiltig Adress. Vänligen försök igen.");
    //        }
//
    //          } while (!isValidInfo);
//
    //          isValidInfo = false;
//
    //          Console.WriteLine($"Adressen har registrerat: {address}");
//
    //          do
    //        {
    //          WriteLine("Vänligen ange din email");
    //        email = ReadLine();
    //      isValidInfo = !string.IsNullOrWhiteSpace(email) && IsValidEmail(email);
//
    //              if (!isValidInfo)
    //            {
    //              WriteLine("Ogiltig email. Vänligen försök igen");
    //        }
//
//
    //          if (existingCustomers.Any(customer => customer.Email == email))
    //        {
    //          Console.WriteLine("Denna e-posten är redan registrerad.");
    //        return;
    //  }
    //} while (!isValidInfo);
//
    //          Console.WriteLine($"Emailet har registrerat: {email}");
//
    //          do
    //        {
    //          Console.WriteLine("Vänligen ange ditt telefonnummer:");
    //        phoneNumber = Console.ReadLine();
//
    //              isValidInfo = !string.IsNullOrWhiteSpace(phoneNumber) && phoneNumber.All(char.IsDigit);
//
    //              if (!isValidInfo)
    //            {
    //              Console.WriteLine("Ogiltigt nummer. Vänligen försök igen.");
    //        }
    //  } while (!isValidInfo);
//
    //          Console.WriteLine($"Telefonnummer registrerat: {phoneNumber}");
//
    //          do
    //        {
    //          Console.WriteLine("Vänligen ange ditt personnummer, 10 siffror:");
    //        personalNumber = Console.ReadLine();
//
    //              isValidInfo = !string.IsNullOrWhiteSpace(personalNumber) && personalNumber.Length == 10 &&
    //                          personalNumber.All(char.IsDigit);
//
    //              if (!isValidInfo)
    //            {
    //              Console.WriteLine("Ogiltigt personnummer. Vänligen försök igen.");
    //        }
    //      else if (existingCustomers.Any(customer => customer.PersonalNumber == personalNumber))
    //    {
    //      Console.WriteLine("Detta personnummer är redan registrerat.");
    //    return;
    // }
    //          } while (!isValidInfo);
//
    //          do
    //        {
    //          Console.WriteLine("Skriv ditt nya lösenord (minst 8 tecken, innehållande bokstäver, siffror och specialtecken):");
    //        password = Console.ReadLine();
//
    //              if (!IsStrongPassword(password))
    //            {
    //              Console.WriteLine("Lösenordet är inte starkt nog. ");
    //            Console.WriteLine(" till att det är minst 8 tecken långt och innehåller bokstäver, siffror och specialtecken.");
    //          continue;
    //    }
//
    //              Console.WriteLine("Bekräfta ditt lösenord igen");
    //            confirmationPassword = Console.ReadLine();
//
    //              if (password != confirmationPassword)
    //            {
    //              Console.WriteLine("Lösenorden matchar inte. Vänligen försök igen.");
    //        }
    //      Console.WriteLine("Lösenordet är bekräftat.");
//
    //          } while (confirmationPassword == null || password != confirmationPassword);
//
//
//
    //          customerId = Customer.GenerateCustomerIdNumber(existingCustomers.GetEnumerator());
//
//
    //          var newCustomer = new Customer(customerId, fullName, address, email, phoneNumber, personalNumber, password, confirmationPassword);
//
    //          FileHandler.AddCustomerToFile(newCustomer); // Korrekt
    //        Console.WriteLine($"Kund: {fullName} är regristrerad med Kund ID {customerId}");
//
//
    //      }
    //    catch (Exception ex)
    //  {
    //    WriteLine($"Ett oväntat fel uppstod: {ex.Message}");
    //  throw;
    //}
    //}
    //private static bool IsStrongPassword(string? password)
    //{
    //  if (string.IsNullOrWhiteSpace(password))
    //    return false;
//
    //      bool hasLetterOrDigit = password.Any(char.IsLetterOrDigit);
    //    bool hasSpecialCharacter = password.Any(ch => !char.IsLetterOrDigit(ch));
    //  bool hasValidLength = password.Length >= 8;
//
    //      return hasLetterOrDigit && hasSpecialCharacter && hasValidLength;
    //}

    //   private static  bool IsValidEmail(string email)
    // {
    //   try
    // {
    //   var address = new System.Net.Mail.MailAddress(email);
    // return address.Address == email;
    // }
    // catch
    //{
    //   return false;
    //}
    //}


}