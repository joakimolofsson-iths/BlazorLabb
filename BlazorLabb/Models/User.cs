using System.ComponentModel.DataAnnotations;

namespace BlazorLabb.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [ValidateComplexType]
        public Address Address { get; set; } = new Address();

        [ValidateComplexType]
        public Company Company { get; set; } = new Company();

        public User()
        {
            Address = new Address();
            Company = new Company();
        }

        public User(int id, string name, string email, string street, string city, string zipCode, string companyName, string companyCatchphrase) 
        {
            Id = id;
            Name = name;
            Email = email;
            Address = new Address
            {
                Street = street,
                City = city,
                ZipCode = zipCode
            };
            Company = new Company
            {
                Name = companyName,
                Catchphrase = companyCatchphrase
            };
        }
    }
}
