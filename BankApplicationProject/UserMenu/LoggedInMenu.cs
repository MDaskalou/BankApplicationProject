using BankApplicationProject.ShowOrUpdateProfile;

namespace BankApplicationProject.UserMenu;

public class LoggedInMenu
{
    public static bool LoggedInMenuOptions(Customer matchingCustomer)
    {
        while (true)
        {
            Console.WriteLine($"Du är nu inloggad {matchingCustomer.FullName}.");
            Console.WriteLine("Välj ett av alternativen nedan.");
            Console.WriteLine("1:Profil.");
            Console.WriteLine("2:Lönekonto.");
            Console.WriteLine("3:SparKonto.");
            Console.WriteLine("4:Invenstreringskonto.");
            Console.WriteLine("5:Avsluta och gå tillbaka till huvudmenyn.");

            string? choice = Console.ReadLine();


            switch (choice)
            {
                case "1":
                    ShowOrUpdatePofileMenu.Show(matchingCustomer);
                    break;
                case "2":
                    SalaryAccountMenu.SalaryAccountOptions(matchingCustomer);
                    break;

                case "3":

                    break;

                case "4":

                    break;

                case "5":
                    Console.WriteLine("Avsluta och går tillbaa till huvudmenyn.");
                    return false;
                    break;

                default:
                    Console.WriteLine("Ogiltigt alternativ. Försök igen");
                    break;

            }
            Console.WriteLine();

        }
    }
}