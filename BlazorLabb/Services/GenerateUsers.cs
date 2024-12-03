using BlazorLabb.Interfaces;
using BlazorLabb.Models;

namespace BlazorLabb.Services
{
    public class GenerateUsers
    {
		private IUsers _apiUsers;
		private IUsers _localUsers;
		private List<User> _users = new();

		public GenerateUsers(ApiUsers apiUsers, LocalUsers localUsers)
		{
            _apiUsers = apiUsers;
			_localUsers = localUsers;
		}

        public async Task<List<User>> GenerateUsersAsync()
        {
            if(_users.Count > 0)
            {
                return _users;
            }

            List<User> jsonUsers = await _apiUsers.GetUsersAsync();

            if(_localUsers is LocalUsers local)
            {
				local.SetLocalStartingId(jsonUsers.Count());
			}
			
			List<User> localUsers = await _localUsers.GetUsersAsync();

            _users.AddRange(jsonUsers);
            _users.AddRange(localUsers);

            return _users;
        }

        public void AddNewUser(User user)
        {
            user.Id = _users.Count + 1;
            _users.Add(user);
        }
    }
}
