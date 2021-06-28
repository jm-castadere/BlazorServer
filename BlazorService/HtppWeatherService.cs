using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BlazorModel;

namespace BlazorService
{
    public class HtppWeatherService: IWeatherForecastService
    {
        private readonly HttpClient _client;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client"></param>
        public HtppWeatherService(HttpClient client)
        {

            _client = client;

        }


        /// <summary>
        /// Get all value
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            //call 
            var response = await _client.GetAsync("weatherForecast");

            if (response.IsSuccessStatusCode)
            {
                //cast reposne to json
                var jsonData = await response.Content.ReadAsStringAsync();
                //Json option
                var jsonOptions = new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true

                };
                //Return json data
                return System.Text.Json.JsonSerializer.Deserialize<WeatherForecast[]>(jsonData, jsonOptions);

            }
            return new WeatherForecast[0];

        }
    }
}
