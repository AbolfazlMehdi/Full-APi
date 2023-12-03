using api.Database;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public UsersController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        [HttpPost("AddUser")]

        public async Task<ActionResult<int>> AddUser([FromBody] UserDTO user)
        {
            if (user == null)
            {
                return BadRequest("User is null");
            }

            var newUser  = new Users{
                Age= user.Age,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MobileNumber = user.MobileNumber,

            };



            _appDbContext.Users.Add(newUser);
            await _appDbContext.SaveChangesAsync();
            return Ok(newUser.UserId);


        }    [HttpPut("UpdateUser/{userId}")]

        public async Task<ActionResult<int>> UpdateUser([FromBody] UserDTO user , int userId)
        {

         var findUser =  _appDbContext.Users.Find(userId);

            
            if (findUser == null)
            {
                return BadRequest("User is null");
            }


            findUser.MobileNumber = user.MobileNumber;
            findUser.FirstName = user.FirstName;
            findUser.LastName = user.LastName;
            findUser.Age = user.Age;
            _appDbContext.Users.Update(findUser);
            await _appDbContext.SaveChangesAsync();
            return Ok(findUser.UserId);


        }

        [HttpGet("GetAllUsers")]

        public IActionResult GetAllUsers()
        {

            var users = _appDbContext.Users.ToList();
            return Ok(users);

        }

        [HttpGet("GetUserById/{userId}")]

        public IActionResult GetUserById(int userId)
        {

            var user = _appDbContext.Users.Find(userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);

        }
    }

}
