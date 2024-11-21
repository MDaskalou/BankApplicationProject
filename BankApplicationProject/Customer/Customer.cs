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
        public string Address { get; set; }

        public Customer(){}

        public Customer (string? customerId, string? fullName, string? adress, string? email,
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
            return FileHandlerAccounts.LoadAccountsFromFile().FindAll(a => a.CustomerId == CustomerId);
        }

        public static string GenerateCustomerIdNumber(IEnumerable<Customer>existingCustomers )
        {
            string newCustomerId;
            var random = new Random();

            do
            {
                newCustomerId = $"CUST{random.Next(100000, 999999)}";
            } while (existingCustomers.Any(customer => customer.CustomerId == newCustomerId));

            return newCustomerId;
        }
    }







}