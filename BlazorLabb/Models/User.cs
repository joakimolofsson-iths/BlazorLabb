namespace BlazorLabb.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Address UserAddress { get; set; } = new Address();
        public Company UserCompany { get; set; } = new Company();

        public User()
        {
            UserAddress = new Address();
            UserCompany = new Company();
        }

        public User(int id, string name, string email, string street, string city, string zipCode, string companyName, string companyCatchphrase) 
        {
            Id = id;
            Name = name;
            Email = email;
            UserAddress = new Address
            {
                Street = street,
                City = city,
                ZipCode = zipCode
            };
            UserCompany = new Company
            {
                Name = companyName,
                Catchphrase = companyCatchphrase
            };
        }
    }
}
