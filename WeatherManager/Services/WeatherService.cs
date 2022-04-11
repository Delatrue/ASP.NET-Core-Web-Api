using System;
using System.Collections.Generic;
using System.Linq;
using WeatherManager.Models;

namespace WeatherManager.Services
{
    public class WeatherService
    {
        static List<Weather> WeatherHolder { get; set; }
        static int nextId = 11;
        static WeatherService()
        {
            WeatherHolder = new List<Weather>()
            {
                new Weather {Id = 1, Date = new DateTime(2022, 4, 1), Temperature = 0.2f},
                new Weather {Id = 2, Date = new DateTime(2022, 4, 2), Temperature = 2.5f},
                new Weather {Id = 3, Date = new DateTime(2022, 4, 3), Temperature = 5.5f},
                new Weather {Id = 4, Date = new DateTime(2022, 4, 4), Temperature = 7.5f},
                new Weather {Id = 5, Date = new DateTime(2022, 4, 5), Temperature = 14.5f},
                new Weather {Id = 6, Date = new DateTime(2022, 4, 6), Temperature = 8.5f},
                new Weather {Id = 7, Date = new DateTime(2022, 4, 7), Temperature = 10.5f},
                new Weather {Id = 8, Date = new DateTime(2022, 4, 8), Temperature = 9.5f},
                new Weather {Id = 9, Date = new DateTime(2022, 4, 9), Temperature = -10.5f},
                new Weather {Id = 10, Date = new DateTime(2022, 4, 10), Temperature = 0f}
            };
        }
        //Добавление значения
        public static void Add(Weather weather)
        {
            weather.Id = nextId++;
            WeatherHolder.Add(weather);
        }
        //Обновление значения по дате
        public static void Update(Weather weather)
        {
            var element = WeatherHolder.FindIndex(index => index.Date == weather.Date);
            if (element == -1)
                return;

            WeatherHolder[element] = weather;
        }
        //Получение значения по дате
        public static Weather Get(DateTime date)
        {
            return WeatherHolder.FirstOrDefault(index => index.Date == date);
        }

        public static void Delete(DateTime date)
        {
            var weather = Get(date);
            if (weather is null)
                return;

            WeatherHolder.Remove(weather);
        }
        //Получение диапозона данных по id
        public static List<Weather> GetAll()
        {
            return WeatherHolder.GetRange(2, 5);
        }

        
    }
}
