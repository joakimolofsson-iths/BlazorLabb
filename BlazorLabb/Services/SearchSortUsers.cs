using BlazorLabb.Components.Pages;
using BlazorLabb.Models;
using System.Reflection.Emit;

namespace BlazorLabb.Services
{
    public static class SearchSortUsers
    {
        public static List<User> Search(List<User> users, string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                return users;
            }

            var searchInputLower = searchInput.ToLower();

            return users.Where(user => MatchSearchWithData(user, searchInputLower)).ToList();
        }

        private static bool MatchSearchWithData(User user, string searchInputLower)
        {
            var propertiesToSearch = new List<string>
            {
                user.Id.ToString(),
                user.Name,
                user.Email,
                user.Address.Street,
                user.Address.City,
                user.Address.ZipCode,
                user.Company.Name,
                user.Company.Catchphrase
            };

            return propertiesToSearch.Any(userData => userData.ToLower().Contains(searchInputLower));
        }

        public static List<User> Selection(List<User> users, string selectedSortOption, bool sortAscending, bool showAllUsers)
        {
            switch (selectedSortOption)
            {
                case "Id":
                    users = sortAscending
                    ? users.OrderBy(user => user.Id).ToList()
                    : users.OrderByDescending(user => user.Id).ToList();
                    break;
                case "Name":
                    users = sortAscending
                    ? users.OrderBy(user => user.Name).ToList()
                    : users.OrderByDescending(user => user.Name).ToList();
                    break;
                case "Email":
                    users = sortAscending
                    ? users.OrderBy(user => user.Email).ToList()
                    : users.OrderByDescending(user => user.Email).ToList();
                    break;
                case "Street":
                    users = sortAscending
                    ? users.OrderBy(user => user.Address.Street).ToList()
                    : users.OrderByDescending(user => user.Address.Street).ToList();
                    break;
                case "City":
                    users = sortAscending
                    ? users.OrderBy(user => user.Address.City).ToList()
                    : users.OrderByDescending(user => user.Address.City).ToList();
                    break;
                case "ZipCode":
                    users = sortAscending
                    ? users.OrderBy(user => user.Address.ZipCode).ToList()
                    : users.OrderByDescending(user => user.Address.ZipCode).ToList();
                    break;
                case "CompanyName":
                    users = sortAscending
                    ? users.OrderBy(user => user.Company.Name).ToList()
                    : users.OrderByDescending(user => user.Company.Name).ToList();
                    break;
                case "CompanyCatchphrase":
                    users = sortAscending
                    ? users.OrderBy(user => user.Company.Catchphrase).ToList()
                    : users.OrderByDescending(user => user.Company.Catchphrase).ToList();
                    break;
                default:
                    users.OrderBy(user => user.Name).ToList();
                    break;
            }

            int showLimitedUsers = 5;
            int? showAllOrLimited = showAllUsers ? null : showLimitedUsers;

            return users.Take(showAllOrLimited ?? int.MaxValue).ToList();
        }

        //Keeping this if ever needed...
        private static int SanitizeZipCode(string zipCode)
        {
            string zipCodeWithoutDash = zipCode.Replace("-", "");
            return int.TryParse(zipCodeWithoutDash, out int result) ? result : -1;
        }
    }
}
