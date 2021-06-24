using BlazorModel;
using System;
using System.Threading.Tasks;

namespace BlazorService
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetForecastAsync(DateTime startDate);
    }

}
