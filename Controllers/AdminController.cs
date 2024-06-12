using AirBnbAPI.Data;
using AirBnbAPI.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AdminController : ControllerBase
{
    private readonly IAnonymousAirBnbDataContext _data;
    private readonly string adminPassword = "adminpassword"; // Hardcoded admin password

    public AdminController(IAnonymousAirBnbDataContext data)
    {
        _data = data;
    }

    [HttpPost("login")]
    public ActionResult Login([FromBody] AdminLoginRequest request)
    {
        if (request.Password == adminPassword)
        {
            return Ok(new { success = true });
        }
        else
        {
            return Ok(new { success = false });
        }
    }

    [HttpGet("spots")]
    public ActionResult<IEnumerable<Spot>> GetSpots()
    {
        var spots = _data.GetSpots();
        return Ok(spots);
    }

    [HttpPost("spots")]
    public ActionResult CreateSpot([FromBody] Spot spot)
    {
        _data.AddSpot(spot);
        return Ok("Spot created successfully");
    }
}