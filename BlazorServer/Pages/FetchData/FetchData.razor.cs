using BlazorModel;
using BlazorService;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BlazorServer.Pages.FetchData
{
    public partial class FetchData
    {

        // services.AddSingleton<IWeatherForecastService, WeatherForecastService>()
        // @inject WeatherForecastService ForecastService
        [Inject]
        protected IWeatherForecastService ForecastService { get; set; }

        private WeatherForecast[] forecasts;

        public DateTime dateEnter { get; set; } = DateTime.Now;

        protected override async Task OnInitializedAsync()
        {
            await GetForecast();
        }


        /// <summary>
        /// Get all value to service
        /// </summary>
        /// <returns>data collection</returns>
        protected async Task GetForecast()
        {
            //Add wait
            //await Task.Delay(1000);

            forecasts = await ForecastService.GetForecastAsync(dateEnter);


        }

        protected async Task GetDate()
        {
            forecasts = await ForecastService.GetForecastAsync(dateEnter);

        }



    }
}
