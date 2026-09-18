using Microsoft.AspNetCore.Mvc;

namespace Ivanov_Denis_Evgenievich_KT_31_23.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Морозно", "Бодряще", "Холодно", "Свежо", "Мягко", "Тепло", "Жарко", "Очень жарко", "Знойно", "Испепеляюще"
    ];

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation("Получение прогноза погоды.");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpPost(Name = "AddWeatherSummary")]
    public IActionResult Post([FromBody] string newSummary)
    {
        _logger.LogInformation("Добавление нового описания погоды: {Summary}", newSummary);
        return Ok($"Описание {newSummary} получено, но не добавлено.");
    }
}
