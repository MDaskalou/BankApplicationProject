namespace BankApplicationProject.UserMenu;

public class LoggedInMenu
{
    public static bool LoggedInMenuOptions(Customer matchingCustomer)
    {
        Console.WriteLine($"Du är nu inloggad {matchingCustomer.FullName}.");
        Console.WriteLine("Välj ett av alternativen nedan.");
        Console.WriteLine("1:Profil.");
        Console.WriteLine("2:Lönekonto.");
        Console.WriteLine("3:SparKonto.");
        Console.WriteLine("4:Invenstreringskonto.");
        Console.WriteLine("5:Avsluta och gå tillbaka till huvudmenyn.");

        string? choice = Console.ReadLine();

        while (true)
        {
            switch (choice)
            {
                case "1":

                    break;
                case "2":

                    break;

                case "3":

                    break;

                case "4":

                    break;

                case "5":

                    break;

                default:
                    Console.WriteLine("Ogiltigt alternativ. Försök igen");
                    break;

            }

        }



    }
}