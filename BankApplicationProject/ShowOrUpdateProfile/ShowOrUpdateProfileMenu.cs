namespace BankApplicationProject.ShowOrUpdateProfile;

public class ShowOrUpdatePofileMenu
{
    public static bool Show(Customer matchingCustomer)
    {
        Console.WriteLine("Vill du se din profil eller uppdatera din profil?");
        Console.WriteLine("1: Se din profil.");
        Console.WriteLine("2: Uppdatera din profil.");
        Console.WriteLine("0: Gå tillbaka till din menu.");
        while (true)
        {
            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    ShowProfileMenu.ShowProfileInfo(matchingCustomer.CustomerId);
                    break;
                case "2":
                    UpdateProfileMenu.UpdateMeny(matchingCustomer);
                    break;
                case "0" :
                    return false;
                default:
                    Console.WriteLine("Felaktigt alternativ. Försök igen");
                    break;


            }
        }
    }
}