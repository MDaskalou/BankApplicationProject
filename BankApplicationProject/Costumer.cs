namespace BankApplicationProject
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int PersonalNumber { get; set; }

        public Customer(string customerId, string fullName, string address, string email, int phoneNumber, int personalNumber)
        {
            CustomerId = customerId;
            FullName = fullName;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
            PersonalNumber = personalNumber;
        }

        public List<Account> GetAccounts()
        {
            return FileHandler.LoadAccountsFromFile().FindAll(a => a.CustomerId == CustomerId);
        }

        public void CreateAccount(AccountType type)
        {
            var newAccount = new Account
            {
                AccountNumber = GenerateAccountNumber(),
                Balance = 0,
                Type = type,
                OpeningDate = DateTime.Now,
                CustomerId = CustomerId
            };
            FileHandler.SaveAccountToFile(newAccount);

        }


        private string GenerateAccountNumber()
        {
            return $"ACC{new Random().Next(100000, 999999)}";
        }
    }







}