namespace BankApplicationProject
{
    public class Customer
    {
        public string? CustomerId { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PersonalNumber { get; set; }
        public string? Password { get; set; }

        public Customer(){}

        public Customer(string s, string? customerId, string? fullName, string? address, string? email,
            string? phoneNumber, string? personalNumber, string? password)
        {
            CustomerId = customerId;
            FullName = fullName;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
            PersonalNumber = personalNumber;
            Password = password;
        }

        public List<Customer> GetAccounts()
        {
            return FileHandlerCustomer.LoadCustomersFromFile().FindAll(customer => customer.CustomerId == CustomerId);
        }




        private string GenerateCustomerIdNumber()
        {
            return $"ACC{new Random().Next(100000, 999999)}";
        }
    }







}