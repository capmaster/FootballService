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
    public class MathController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
         private readonly IMathService _mathService;

        public MathController(IMathService mathService,
                             ILogger<WeatherForecastController> logger)
        {
            _mathService = mathService;
            _logger = logger;
        }

        [HttpGet]
        public string Get([FromQuery(Name = "roman")] string roman)
        {
           if(string.IsNullOrEmpty(roman)) 
                return "format: http://baseurl/Math?roman=MX";

           var arabicNumber =  _mathService.RomanToArabic(roman);
           return Convert.ToString(arabicNumber);
        }
    }
}
