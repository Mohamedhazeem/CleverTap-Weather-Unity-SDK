namespace CleverTap.WeatherSDK.Config
{
    public class WeatherURLConfig
    {
        public string BaseUrl { get; set; }

        public WeatherURLConfig(string baseUrl)
        {
            BaseUrl = baseUrl;
        }
    }
}
