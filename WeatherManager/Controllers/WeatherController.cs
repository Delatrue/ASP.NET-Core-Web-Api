using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WeatherManager.Models;
using WeatherManager.Services;

namespace WeatherManager.Controllers
{
    [Route("")]
    [ApiController]
    public class WeatherController : ControllerBase
    {

        [HttpPost]
        public IActionResult Create(Weather weather)
        {
            WeatherService.Add(weather);
            return CreatedAtAction(nameof(Create), new { id = weather.Id }, weather);
        }

        [HttpPut("{date}")]
        public IActionResult Update(DateTime date, Weather weather)
        {
            if (date != weather.Date)
                return BadRequest();

            var getWeather = WeatherService.Get(date);
            if (getWeather is null)
                return NotFound();

            WeatherService.Update(weather);

            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<Weather>> GetAll()
        {
            return WeatherService.GetAll();
        }

        [HttpDelete("{date}")]
        public IActionResult Delete(DateTime date)
        {
            var weather = WeatherService.Get(date);

            if (weather is null)
                return NotFound();

            WeatherService.Delete(date);

            return NoContent();
        }
    }
}
