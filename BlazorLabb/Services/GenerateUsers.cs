﻿using BlazorLabb.Components.Pages;
using BlazorLabb.Models;
using System.Text.Json;

namespace BlazorLabb.Services
{
    public class GenerateUsers
    {
        private readonly HttpClient _httpClient;
        private static readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public List<User> Users { get; private set; } = new();
        public string ?ErrorMsg { get; private set; }

        public GenerateUsers(HttpClient httpClient) 
        {
            _httpClient = httpClient;
            GenerateUsersAsync();
        }

        private async Task GenerateUsersAsync()
        {
            await FetchJsonUsersAsync();
            GenerateLocalUsers();
        }

        private async Task FetchJsonUsersAsync()
        {
            try
            {
                var respone = await _httpClient.GetStringAsync("users");
                var usersFromJson = JsonSerializer.Deserialize<List<User>>(respone, _options);

                Users = usersFromJson;
            }
            catch (HttpRequestException e)
            {
                ErrorMsg = "Http Request Error...";
            }
            catch (Exception e)
            {
                ErrorMsg = "Something went wrong...";
            }
        }

        private void GenerateLocalUsers()
        {
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
                Users.Add(new User(Users.Count + (i + 1), names[i], emails[i], streets[i], cities[i], zipCodes[i], companyNames[i], companyCatchphrases[i]));
            }
        }
    }
}