using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PrevisaoDoTempoController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<PrevisaoDoTempoController> _logger;

    public PrevisaoDoTempoController(ILogger<PrevisaoDoTempoController> logger)
    {
        _logger = logger;
    }
    //Name = "PrevisaoDoTempo"
    [HttpGet("Temperaturas")]
    public IEnumerable<PrevisaoDoTempo> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new PrevisaoDoTempo
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
