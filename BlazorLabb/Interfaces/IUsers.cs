using BlazorLabb.Models;

namespace BlazorLabb.Interfaces
{
    public interface IUsers
    {
        Task<List<User>> GetUsersAsync();
    }
}
