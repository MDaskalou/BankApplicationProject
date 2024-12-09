namespace BankApplicationProject;

public class SalaryAccountMenu
{

    public static bool SalaryAccountOptions(Customer matchingCustomer)
    {
        var salaryAccount = matchingCustomer.SalaryAccount;
        if (salaryAccount == null)
        {
            Console.WriteLine("Du har inget Lönekonto ");
            return false;
        }
        while (true)
        {
            Console.WriteLine($@"Hej {matchingCustomer.FullName} och välkommen till ditt lönekonto");
            Console.WriteLine("Välj ett av alternativen");
            Console.WriteLine("1: Se ditt saldo");
            Console.WriteLine("2: Sätta in pengar");
            Console.WriteLine("3: Ta ut pengar");
            Console.WriteLine("4: Överföra pengar");
            Console.WriteLine("5: Se historiken");
            Console.WriteLine("0: Avsluta och tillbaka till menyn");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                        Console.WriteLine($"Ditt saldo är : {salaryAccount.GetBalance()} kr");
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "0":
                    return false;
                default:
                        Console.WriteLine("Felaktig alternativ. Försök igen");
                    break;
            }
        }




    }
}