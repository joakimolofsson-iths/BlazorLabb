using BlazorLabb.Components.Pages;
using BlazorLabb.Interfaces;
using BlazorLabb.Models;
using System.Text.Json;

namespace BlazorLabb.Services
{
    public class GenerateUsers : IUsers
    {
        private readonly HttpClient _httpClient;
        private static readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true
        };
        private List<User> _users = new();
        public string ?ErrorMsg { get; private set; }

        public GenerateUsers(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            if(_users.Count > 0)
            {
                return _users;
            }

            List<User> jsonUsers = await FetchJsonUsersAsync();
            List<User> localUsers = GenerateLocalUsers(jsonUsers);

            _users.AddRange(jsonUsers);
            _users.AddRange(localUsers);

            return _users;
        }

        private async Task<List<User>> FetchJsonUsersAsync()
        {
            try
            {
                var respones = await _httpClient.GetStringAsync("users");
                var usersFromJson = JsonSerializer.Deserialize<List<User>>(respones, _options);

                return usersFromJson;
            }
            catch (HttpRequestException e)
            {
                ErrorMsg = "Http Request Error...";
                return new List<User>();
            }
            catch (Exception e)
            {
                ErrorMsg = "Something went wrong...";
                return new List<User>();
            }
        }

        private List<User> GenerateLocalUsers(List<User> jsonUsers)
        {
            List<User> localUsers = new();

            string[] names = { "Emma Hayes", "Liam Carter", "Ava Brooks", "Noah Hughes", "Mia Bennett", "Ethan Price", "Sophia Rogers", "Oliver Reed", "Isabella Morgan", "Lucas Green" };
            string[] emails = { "bluefox87@mail.com", "sparklewave42@inbox.com", "sunnyclouds23@webmail.com", "silverstream55@netmail.com", "moonlitowl78@fastmail.com", "crimsonleaf91@mailbox.com", "goldenpetal34@postmail.com", "starfall16@freemail.com", "shimmeringsky45@quickmail.com", "wildriver82@openmail.com" };
            string[] streets = { "123 Maple St.", "456 Oak Ave.", "789 Pine Rd.", "101 Cedar Blvd.", "202 Birch Ln.", "303 Walnut St.", "404 Elm Dr.", "505 Chestnut Pl.", "606 Spruce Ct.", "707 Redwood Ter." };
            string[] cities = { "Springfield", "Rivertown", "Mapleton", "Brookside", "Lakeview", "Hillside", "Fairview", "Greendale", "Sunnydale", "Willowbrook" };
            string[] zipCodes = { "12345", "23456", "34567", "45678", "56789", "67890", "78901", "89012", "90123", "01234" };
            string[] companyNames = { "Greenfield Corp.", "Skyline Ventures", "Sunrise Innovations", "Peak Solutions", "Global Synergy", "BrightPath LLC", "NextGen Labs", "Blue Horizon Inc.", "Edge Dynamics", "VividTech" };
            string[] companyCatchphrases = { "Innovate Your Future", "Bringing Ideas to Life", "Where Vision Meets Reality", "Beyond the Horizon", "Empowering Possibilities", "Inspiring Growth", "Redefining Excellence", "The Future, Today", "Shaping Tomorrow", "Excellence Through Innovation" };

            // var random = new Random();
            // int randomNumber = random.Next(0, 10);

            for (int i = 0; i < 10; i++)
            {
                localUsers.Add(new User(jsonUsers.Count + (i + 1), names[i], emails[i], streets[i], cities[i], zipCodes[i], companyNames[i], companyCatchphrases[i]));
            }

            return localUsers;
        }

        public void AddNewUser(User user)
        {
            user.Id = _users.Count + 1;
            _users.Add(user);
        }
    }
}
