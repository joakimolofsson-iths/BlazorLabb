using BlazorLabb.Interfaces;
using BlazorLabb.Models;
using System.Text.Json;

namespace BlazorLabb.Services
{
	public class ApiUsers : IUsers
	{
		private readonly HttpClient _httpClient;
		private static readonly JsonSerializerOptions _options = new()
		{
			PropertyNameCaseInsensitive = true
		};
		public string? ErrorMsg { get; private set; }

		public ApiUsers(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<User>> GetUsersAsync()
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
	}
}
