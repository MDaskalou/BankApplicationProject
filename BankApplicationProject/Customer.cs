namespace BankApplicationProject



{
    public class Customer
    {
        public string? CustomerId { get; set; }
        public string? FullName { get; set; }
        public string? Adress { get; set; }
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? PersonalNumber { get; set; }
        public string? Password { get; set; }

        public Customer(){}

        public Customer(string? s, string? customerId, string? fullName, string? adress, string? email,
            string? phoneNumber, string? personalNumber, string? password)
        {
            CustomerId = customerId;
            FullName = fullName;
            Adress = adress;
            Email = email;
            PhoneNumber = phoneNumber;
            PersonalNumber = personalNumber;
            Password = password;
        }

        public List<Account> GetAccounts()
        {
            return FileHandler.LoadAccountsFromFile().FindAll(a => a.CustomerId == CustomerId);
        }

        public void CreateAccount(AccountType type)
        {
            var newAccount = new Account
            {
                CustomerId = GenerateCustomerIdNumber(null),
                Balance = 0,
                Type = type,
                OpeningDate = DateTime.Now,
            };
            FileHandler.SaveAccountToFile(newAccount);

        }


        public static string GenerateCustomerIdNumber(IEnumerator<Customer>existingCustomers )
        {
            string newCustomerId;
            var random = new Random();
            var customerList = new List<Customer>();

            while (existingCustomers.MoveNext())
            {
                customerList.Add(existingCustomers.Current);
            }

            do
            {
                newCustomerId = $"CUST{random.Next(100000, 999999)}";
            } while (customerList.Any(customer => customer.CustomerId == newCustomerId));

            return newCustomerId;
        }
    }







}