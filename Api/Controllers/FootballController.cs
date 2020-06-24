using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Service;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FootballController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IFootballService _footballService;

        public FootballController(IFootballService footballService, ILogger<WeatherForecastController> logger)
        {
            _footballService = footballService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Standing> Get([FromQuery(Name = "country")] string country,
                                                    [FromQuery(Name = "league")] string league,
                                                    [FromQuery(Name = "team")] string team)
        {
           var standings =  _footballService.GetStandings(country, league, team);
           return standings;
        }
    }
}
