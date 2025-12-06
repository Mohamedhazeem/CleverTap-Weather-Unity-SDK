using System.Threading.Tasks;

namespace CleverTap.WeatherSDK.WeatherAPI
{
    public interface IWeatherService
    {
        Task<float> GetCurrentTemperatureAsync(float lat, float lon);
        Task<float> GetTodayMaxTemperatureAsync(float lat, float lon);
    }

}
