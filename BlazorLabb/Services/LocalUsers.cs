using BlazorLabb.Interfaces;
using BlazorLabb.Models;

namespace BlazorLabb.Services
{
	public class LocalUsers : IUsers
	{
		private int _startingId;

		public Task<List<User>> GetUsersAsync()
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
				localUsers.Add(new User(_startingId + i, names[i], emails[i], streets[i], cities[i], zipCodes[i], companyNames[i], companyCatchphrases[i]));
			}

			return Task.FromResult(localUsers);
		}

		public void SetLocalStartingId(int startingId)
		{
			_startingId = startingId + 1;
		}
	}
}
