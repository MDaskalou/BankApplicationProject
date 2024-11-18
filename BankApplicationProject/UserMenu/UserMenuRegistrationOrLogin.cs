using BankApplicationProject.RegistrationOrLogin;

namespace BankApplicationProject.UserMenu;

public class UserMenuRegistrationOrLogin
{


    public static void RegisterMenu()
    {
        bool exit = false;

        while(!exit)
        {
            Console.Clear();
            Console.WriteLine("Välkommen till Mikaels Bank!");
            Console.WriteLine("Nedanför har du två alternativ.");
            Console.WriteLine("1:Registrera dig.");
            Console.WriteLine("2:Logga in.");
            Console.WriteLine("3:Avsluta programmet.");

            string choice = Console.ReadLine();

                switch (choice)
                {
                     case "1":
                         Console.WriteLine(("Du har valt att regristrera dig"));
                         Console.WriteLine("1:Tack för att du har valt Mikaels Bank!");
                         Console.WriteLine("Föratt gå vidare behöver vi lite information om dig.");
                         Console.WriteLine("Vänliggen fyll informationen om dig.");
                         Console.ReadKey();
                         Console.Clear();
                         Registration.RegisterNewCostumer();
                         Console.ReadKey();
                         Console.Clear();
                         Console.WriteLine("Tack för att du valde Mikaels Bank!");
                         Console.WriteLine(("För att logga in tryck enter för att komma tillbaka till huvudmenyn."));
                         break;
                     case "2":
                         Login.LoginToBank();
                         break;
                     case "3":
                         exit = true;
                         break;
                     default:
                         Console.WriteLine("Ogiltigt val. Försök igen.");
                         Console.ReadKey();
                         break;
                }
        }
        Console.WriteLine("Tack för att du använde Mikaels Bank. Välkommen åter1!");

    }
}