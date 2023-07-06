using TaskManagementSystemAPI.Models;

namespace TaskManagementSystemAPI.Repo
{
    public interface IUserRepo
    {
        Task<List<User>> GetUsers();
        Task<string> CreateUser(User user);
        Task<string> UpdateUser(User user,Guid USER_ID);
        Task<string> DeleteUser(Guid USER_ID);
    }
}
