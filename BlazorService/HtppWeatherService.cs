using BlazorModel;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorModel.Opts;
using Microsoft.Extensions.Options;

namespace BlazorService
{
    /// <summary>
    /// Service to call API
    /// </summary>
    public class HtppWeatherService : IWeatherForecastService
    {
        private readonly HttpClient _client;
        //Resilience value
        //private readonly IOptions<ApiOptions> _options;

        /// <summary>
        /// Constructor set htpp api
        /// </summary>
        /// <param name="client">htpp client</param>
        public HtppWeatherService(HttpClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Constructor set htpp api with resilience
        /// </summary>
        /// <param name="client">htpp client</param>
        /// <param name="options">app-settings value</param>
        //public HtppWeatherService(HttpClient client, IOptions<ApiOptions> options)
        //{
        //    _client = client;
        //    _options = options;
        //}


        /// <summary>
        /// Service Get all value
        /// </summary>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            try
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return new WeatherForecast[0];


            //Resilience 
            ////Count retry
            //int retry = 0;
            ////loop if resppnse not sucess
            //while (!response.IsSuccessStatusCode)
            //{
            //    //Wait (value appsetting)
            //    await Task.Delay(_options.Value.Delay);
            //    response = await _client.GetAsync("WeatherForecast");

            //    //set retry
            //    retry++;

            //    //Check number retry
            //    if (retry >= _options.Value.RetryMax)
            //    {
            //        break;
            //    }
            //}
        }

    }
}
