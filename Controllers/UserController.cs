using AirBnbAPI.Data;
using AirBnbAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace AirBnbAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
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
            if (existingUser.Password != user.Password)
            {
                return BadRequest("Invalid password");
            }
            return Ok(existingUser);
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody] User user)
        {
            _data.AddUser(user);
            return Ok("User registered");
        }

        [HttpGet("users")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_data.GetUsers());
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _data.DeleteUser(id);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok("User deleted");
        }
    }
}
