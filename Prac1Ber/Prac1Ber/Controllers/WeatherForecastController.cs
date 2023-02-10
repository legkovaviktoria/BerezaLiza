using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Prac1Ber.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<string> Get()
        {
            return Summaries;
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            if(name == null)
            {
                return BadRequest("Введите значение!!!");
            }

            Summaries.Add(name);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if(index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такой индекс неверный!!!");
            }
            if (name == null)
            {
                return BadRequest("Введите значение!!!");
            }
            Summaries[index] = name;
            return Ok();

        }

        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такой индекс неверный!!!");
            }
            Summaries.RemoveAt(index);
            return Ok();
        }

        //2
        [HttpGet("{index}")]
        public string FindI(int index)
        {

            if (index < 0 || index >= Summaries.Count)
            {
                return Summaries[index];
                
            }
            return "Такой индекс неверный!!!";
        }

        //3
        [HttpGet("{find-by-name}")]
        public int Find(string name)
        {
            int count = 0;
            for (int i = 0; i < Summaries.Count; i++)
            {
                if (Summaries[i] == name)
                { count++; }
            }
            return count;
        }

        [HttpGet]
        public IActionResult GetAll(int? sortStrategy)
        {
            if (sortStrategy == null) return (IActionResult)Summaries;
            if(sortStrategy == 1)
            {
                Summaries.Sort();
                return (IActionResult)Summaries;
            }
            if(sortStrategy == -1)
            {
                Summaries.Sort();
                Summaries.Reverse();
                return (IActionResult)Summaries;
            }
            return Ok();
        }


    }
}