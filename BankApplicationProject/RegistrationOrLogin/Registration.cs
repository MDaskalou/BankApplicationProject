namespace BankApplicationProject.RegistrationOrLogin;

public class Registration
{
    public void RegisterNewCostumer()
    {
        string? fullName;
        string? adress;
        string? email;
        int phoneNumber;
        int personalNumber;

        bool isValidInfo = false;

        try
        {
            do
            {
                Console.WriteLine("Vänligen ange ditt namn (Både förnamn och efternamn)");
                fullName = Console.ReadLine();
                isValidInfo = !string.IsNullOrWhiteSpace(fullName);

                if (!isValidInfo)
                {
                    Console.WriteLine("Ogiltigt namn. Vänligen försök igen.");
                }
            }while(!isValidInfo);

            isValidInfo = false;

            do
            {

                    Console.WriteLine("Vänligen ange adress");
                    adress = Console.ReadLine();
                    isValidInfo = !string.IsNullOrWhiteSpace(adress);
                    if(!isValidInfo)
                    {
                        Console.WriteLine("Ogiltig Adress. Vänligen försök igen.");
                    }

            } while (!isValidInfo);
            isValidInfo = false;
            do
            {
                Console.WriteLine("Vänligen ange din email");
                email = Console.ReadLine();
                isValidInfo = !string.IsNullOrWhiteSpace(email);

                if(!isValidInfo)
                {
                    Console.WriteLine("Ogiltig email. Vänligen försök igen" );
                }
            } while (!isValidInfo);

            do
            {
                Console.WriteLine("Vänligen ange ditt telefonnumber");
                phoneNumber = int.TryParse(Console.ReadLine(), out phoneNumber);

                if (isValidInfo)
                {
                    
                }
            } while (email);






        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

}