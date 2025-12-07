using System.Threading.Tasks;
using CleverTap.WeatherSDK.WeatherAPI;

public class MockWeatherService : IWeatherService
{
    public Task<float> GetCurrentTemperatureAsync(float lat, float lon)
    {
        return Task.FromResult(25f); // always return 25°C
    }

    public Task<float> GetTodayMaxTemperatureAsync(float lat, float lon)
    {
        return Task.FromResult(30f); // always return 30°C
    }
}
