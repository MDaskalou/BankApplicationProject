namespace BankApplicationProject;

public class SavingsAccount : Account
{
      public decimal InterestRate { get; private set; }
      public int WithdralsThisMonth { get; private set; }
      private const int MaxMonthlyWithdrals = 3;

 public SavingsAccount(string customerId, decimal interestRate = 0.02m) : base(customerId)
 {
  InterestRate = interestRate;
  WithdralsThisMonth = 0;
 }



 public override bool Withdraw(decimal amount)
 {
    if(WithdralsThisMonth >= MaxMonthlyWithdrals)
    {
        return false;
    }

    if (base.Withdraw(amount))
    {
        WithdralsThisMonth++;
        return true;
    }
    return false;
 }

 public void ApplyMonthlyInterest(int intrestRate)
 {
     decimal intrest = Balance * (intrestRate / 12);
     Balance -= intrest;
     SaveAccount();
 }
}
