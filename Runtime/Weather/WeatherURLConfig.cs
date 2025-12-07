namespace CleverTap.WeatherSDK.Config
{
    public static class DefaultWeatherConfig
    {
        public static readonly WeatherURLConfig Default = new(
            "https://api.open-meteo.com/v1/forecast?timezone=IST&current_weather=true&daily=temperature_2m_max"
        );
    }
    public class WeatherURLConfig
    {
        public string BaseUrl { get; set; }

        public WeatherURLConfig(string baseUrl)
        {
            BaseUrl = baseUrl;
        }
    }
}
