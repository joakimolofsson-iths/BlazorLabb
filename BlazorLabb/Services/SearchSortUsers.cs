using BlazorLabb.Models;

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

                return users.Where(search => search.Id.ToString().StartsWith(_searchInputLower) ||
                    search.Name.ToLower().StartsWith(_searchInputLower) ||
                    search.Email.ToLower().StartsWith(_searchInputLower) ||
                    search.Address.Street.ToLower().StartsWith(_searchInputLower) ||
                    search.Address.City.ToLower().StartsWith(_searchInputLower) ||
                    search.Address.ZipCode.StartsWith(_searchInputLower) ||
                    search.Company.Name.ToLower().StartsWith(_searchInputLower) ||
                    search.Company.Catchphrase.ToLower().StartsWith(_searchInputLower))
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
                default:
                    users.OrderBy(user => user.Name).ToList();
                    break;
            }

            int showLimitedUsers = 5;
            int? showAllOrLimited = showAllUsers ? null : showLimitedUsers;

            return users.Take(showAllOrLimited ?? int.MaxValue).ToList();
        }
    }
}
