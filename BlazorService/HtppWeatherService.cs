using BlazorModel;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorService
{
    /// <summary>
    /// Service to call API
    /// </summary>
    public class HtppWeatherService: IWeatherForecastService
    {
        private readonly HttpClient _client;

        /// <summary>
        /// Constructor set htpp api
        /// </summary>
        /// <param name="client"></param>
        public HtppWeatherService(HttpClient client)
        {

            _client = client;

        }


        /// <summary>
        /// Service Get all value
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            //call API-> WeatherForecastController
            var response = await _client.GetAsync("WeatherForecast");

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
