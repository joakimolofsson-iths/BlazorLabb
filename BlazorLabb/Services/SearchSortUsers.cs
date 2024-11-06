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
            else
            {
                var _searchInputLower = searchInput.ToLower();

                return users.Where(search => search.Id.ToString().Contains(_searchInputLower) ||
                    search.Name.ToLower().Contains(_searchInputLower) ||
                    search.Email.ToLower().Contains(_searchInputLower) ||
                    search.Address.Street.ToLower().Contains(_searchInputLower) ||
                    search.Address.City.ToLower().Contains(_searchInputLower) ||
                    search.Address.ZipCode.Contains(_searchInputLower) ||
                    search.Company.Name.ToLower().Contains(_searchInputLower) ||
                    search.Company.Catchphrase.ToLower().Contains(_searchInputLower))
                    .ToList();
            }
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
