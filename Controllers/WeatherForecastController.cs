using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.Extensions.Options;


namespace ApiTest.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IMapper _mapper;
    private readonly Location _location;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IMapper mapper, IOptions<Location> locationOption)
    {
        _logger = logger;
        _mapper = mapper;
        _location = locationOption.Value;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet]
    [Route("user")]
    public ActionResult<User> GetUser()
    {
        var user = new User
        {
            Id = 1,
            FirstName = "Cathy",
            LastName = "Tester",
            Email = "cathytest@gmail.com",
            Address = "12 Bridge rd, Sydney, NSW 2000"
        };

        var userResult = _mapper.Map<UserViewModel>(user);

        return Ok(userResult);

    }

    [HttpGet]
    [Route("location")]
    public ActionResult<Location> GetLocation() => Ok($"{_locationOption} Test");
   
}
