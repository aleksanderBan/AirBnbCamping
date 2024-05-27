using AirBnbAPI.Data;
using AirBnbAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirBnbAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        //private IAnonymousAirBnbDataContext _data;

        private readonly IAnonymousAirBnbDataContext _data;

        public UserController(IAnonymousAirBnbDataContext data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] User user)
        {
            var existingUser = _data.GetUsers().FirstOrDefault(u => u.UserName == user.UserName);
            if (existingUser == null)
            {
                return NotFound("User not found");
            }
            // Here you should check the password, but for simplicity, we skip this step
            return Ok(existingUser);
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody] User user)
        {
            _data.AddUser(user);
            return Ok("User registered");
        }

        //[HttpPut("update")]
        //public ActionResult Update([FromBody] User user)
        //{
        //    var existingUser = _data.GetUsers().FirstOrDefault(u => u.Id == user.Id);
        //    if (existingUser == null)
        //    {
        //        return NotFound("User not found");
        //    }
        //    existingUser.UserName = user.UserName;
        //    // Update other fields as necessary
        //    _data.UpdateUser(existingUser);
        //    return Ok("User updated");

        //}

        [HttpGet("users")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_data.GetUsers());
        }
    }
}
