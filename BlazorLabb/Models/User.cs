namespace BlazorLabb.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Address UserAddress { get; set; } = new Address();
        public Company UserCompany { get; set; } = new Company();
    }
}
