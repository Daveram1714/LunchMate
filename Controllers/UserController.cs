using Domain.Entities;
using Domain.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace LunchMate_updated.Controllers
{
    [ApiController]
    [Route("")]
    public class UserController : ControllerBase
    {
        private readonly CreateUser _createUser;
        private readonly UpdateUser _updateUser;
        private readonly GetAllUser _getAllUsers;
        private readonly GetUser _getUser;
        private readonly DeletUser _deletUser;

        public UserController(CreateUser createUser, UpdateUser updateUser, GetAllUser getAllUsers, GetUser getUser, DeletUser deletUser)
        {
            _createUser = createUser;
            _updateUser = updateUser;
            _getAllUsers = getAllUsers;
            _getUser = getUser;
            _deletUser = deletUser;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            await _createUser.ExecuteAsync(user);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            await _getUser.ExecuteAsync(id);
            return Ok();    
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _getAllUsers.GetAllUserAsync();
            return Ok(users);
        }
        /*
                [HttpPut("{id}")]
                public async Task<IActionResult> UpdateUser(int id,User user)
                {
                    if (id == 0) return BadRequest();           
                    await _updateUser.ExececuteAsyc(user);
                    return Ok();
                }*/

/*        [HttpDelete]
        public async Task<IActionResult> DeletUser(int id)
        {
            await _deletUser.ExecuteAsync(id);
            return Ok();
        }*/
    }
}
