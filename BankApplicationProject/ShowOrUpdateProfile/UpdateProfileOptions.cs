namespace BankApplicationProject.ShowOrUpdateProfile;

public class UpdateProfileOptions
{
    public static bool ChangeName(Customer matchingCustomer)
    {
        Console.Write("Ange ditt nya namn: ");
        var newName = Console.ReadLine();

        while (true)
        {

            if (string.IsNullOrWhiteSpace(newName))
            {
                Console.Write("Namn kan inte vara tom. Försök igen");
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(newName, @"^[0-9_]*$"))
            {
                Console.WriteLine("Namnet kan inte ha några siffror");
            }
            else
            {
                matchingCustomer.FullName = newName;
                FileHandlerCustomer.SaveupdateCustomersToFile(matchingCustomer);
                Console.WriteLine($"Ditt namn har uppdaterats till {matchingCustomer.FullName}");
                break;
            }
        }
        return true;
    }

    public static bool ChangeAddress(Customer matchingCustomer)
    {
        Console.Write("Ange ditt nya adress: ");
        var newAddress = Console.ReadLine();

        while (true)
        {
            if (string.IsNullOrWhiteSpace(newAddress))
            {
                Console.WriteLine("Adresen kan inte vara tom");
            }
            else
            {
                matchingCustomer.Address = newAddress;
                FileHandlerCustomer.SaveupdateCustomersToFile(matchingCustomer);
                Console.WriteLine($"Din nya adress har uppdaterats till {matchingCustomer.Address} ");
            }
        }
        return true;
    }

    public static bool ChangeEmail(Customer matchingCustomer)
    {
        Console.Write("Ange ditt nya email: ");
        var newEmail = Console.ReadLine();

        while (true)
        {
            if (string.IsNullOrWhiteSpace(newEmail))
            {
                Console.WriteLine("Email kan inte vara tom");
            }
            else
            {
                matchingCustomer.Email = newEmail;
                FileHandlerCustomer.SaveupdateCustomersToFile(matchingCustomer);
                Console.WriteLine($"Email har uppdaterats till {matchingCustomer.Email} ");
            }
        }
        return true;
    }

    public static bool ChangePhoneNumber(Customer matchingCustomer)
    {
        Console.Write("Ange ditt nya telefon: ");
        var newPhoneNumber = Console.ReadLine();

        while (true)
        {
            if (string.IsNullOrWhiteSpace(newPhoneNumber))
            {
                Console.WriteLine("Telefon kan inte vara tom");
            }
            else
            {
                matchingCustomer.PhoneNumber = newPhoneNumber;
                FileHandlerCustomer.SaveupdateCustomersToFile(matchingCustomer);
                Console.WriteLine($"Telefon har uppdaterats till {matchingCustomer.PhoneNumber} ");
            }

        }
        return true;
    }

    public static bool ChangePassword(Customer matchingCustomer)
    {
        Console.Write("Ange ditt nya lösenord: ");
        var newPassword = Console.ReadLine();

        while (true)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                Console.WriteLine("Lösenordet kan inte vara tom");
            }
            else
            {
                matchingCustomer.Password = newPassword;
                FileHandlerCustomer.SaveupdateCustomersToFile(matchingCustomer);
                Console.WriteLine($"Lösenordet har uppdaterats till {matchingCustomer.Password} ");
            }
        }
        return true;
    }
}