using Dapper;
using System.Data;
using TaskManagementSystemAPI.Models;
using TaskManagementSystemAPI.Models.Data;

namespace TaskManagementSystemAPI.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly DapperDbContext context;
        public UserRepo(DapperDbContext context)
        {
            this.context= context;
        }
        public async Task<List<User>> GetUsers()
        {
            string query = "Select * From USERS";
            using (var connection = this.context.CreateConnection())
            {
                var userlist = await connection.QueryAsync<User>(query);
                return userlist.ToList();
            }
        }
        public async Task<string> CreateUser(User user)
        {
            string response = string.Empty;
            string query = "Insert into USERS (USER_ID,USERNAME,PASSWORD,EMAIL) VALUES(@USER_ID,@USERNAME,@PASSWORD,@EMAIL)";
            var parameters = new DynamicParameters();
            user.USER_ID=Guid.NewGuid();
            parameters.Add("USER_ID", user.USER_ID, DbType.Guid);
            parameters.Add("USERNAME", user.USERNAME,DbType.String);
            parameters.Add("PASSWORD", user.PASSWORD, DbType.String);
            parameters.Add("EMAIL", user.EMAIL, DbType.String);
            using (var connection = this.context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;
        }

        public async Task<string> DeleteUser(Guid USER_ID)
        {
            string response = string.Empty;
            string query = "Delete From USERS where USER_ID=@USER_ID";
            using (var connection = this.context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new {USER_ID});
                response= "pass";
            }
            return response;
        }

        public async Task<string> UpdateUser(User user, Guid USER_ID)
        {
            string response = string.Empty;
            string query = "update USERS set USERNAME=@USERNAME, PASSWORD=@PASSWORD,EMAIL=@EMAIL where USER_ID=@USER_ID ";
            var parameters = new DynamicParameters();
            parameters.Add("USER_ID", user.USER_ID, DbType.Guid);
            parameters.Add("USERNAME", user.USERNAME, DbType.String);
            parameters.Add("PASSWORD", user.PASSWORD, DbType.String);
            parameters.Add("EMAIL", user.EMAIL, DbType.String);
            using (var connection = this.context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;
        }
    }
}
