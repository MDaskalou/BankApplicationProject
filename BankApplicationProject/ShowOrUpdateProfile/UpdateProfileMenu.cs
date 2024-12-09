namespace BankApplicationProject.ShowOrUpdateProfile;

public class UpdateProfileMenu
{
    private const string CustomersFileName = @"C:\BankData\BankApplicationData.json";
    public static bool UpdateMeny(Customer matchingCustomer)
    {
        try
        {
            while (true)
            {
                Console.WriteLine($"Hej {matchingCustomer.FullName}");
                Console.WriteLine("Vad vill du uppdatera?");
                Console.WriteLine("1: Namn");
                Console.WriteLine("2: Adress");
                Console.WriteLine("3: Email");
                Console.WriteLine("4: Telefon");
                Console.WriteLine("5: Lösenord");
                Console.WriteLine("0: Avsluta och tillbaka till menyn");



            string choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        UpdateProfileOptions.ChangeName(matchingCustomer);
                        break;
                    case "2":
                       UpdateProfileOptions.ChangeAddress(matchingCustomer);
                        break;
                    case "3":
                        UpdateProfileOptions.ChangeEmail(matchingCustomer);
                        break;
                    case "4":
                        UpdateProfileOptions.ChangePhoneNumber(matchingCustomer);
                        break;
                    case "5":
                        UpdateProfileOptions.ChangePassword(matchingCustomer);
                        break;
                    case "0":
                        return true;
                        break;

                    default:
                        Console.WriteLine("Felaktig alternativ försök igen");
                        break;

                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
}