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

    [HttpGet("spots/{id}")]
    public ActionResult<Spot> GetSpotById(int id)
    {
        var spot = _data.GetSpotById(id);
        if (spot == null)
        {
            return NotFound("Spot not found");
        }
        return Ok(spot);
    }

    [HttpPost("spots/{id}/availability")]
    public ActionResult UpdateSpotAvailability(int id, [FromBody] AvailabilityUpdateRequest request)
    {
        var spot = _data.GetSpotById(id);
        if (spot == null)
        {
            return NotFound("Spot not found");
        }

        spot.IsAvailable = request.IsAvailable;
        _data.UpdateSpot(spot);

        return Ok("Spot availability updated successfully");
    }

    public class AvailabilityUpdateRequest
    {
        public bool IsAvailable { get; set; }
    }
}