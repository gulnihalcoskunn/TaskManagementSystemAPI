using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystemAPI.Models;
using TaskManagementSystemAPI.Repo;

namespace TaskManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo repo;
        public UserController(IUserRepo repo)
        {
                this.repo = repo;
        }
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var _list = await this.repo.GetUsers();
            if (_list != null) 
            { 
                return Ok( _list);
            }
            else
            {
                return NotFound();

            }
        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            var _result = await this.repo.CreateUser(user);
            return Ok(_result);
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] User user,Guid USER_ID )
        {
            var _result = await this.repo.UpdateUser(user,USER_ID);
            return Ok(_result);
        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser( Guid USER_ID)
        {
            var _result = await this.repo.DeleteUser(USER_ID);
            return Ok(_result);
        }
    }
}
