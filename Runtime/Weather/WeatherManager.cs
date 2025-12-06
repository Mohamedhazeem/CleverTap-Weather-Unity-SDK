using System.Threading.Tasks;
using UnityEngine;
using CleverTap.WeatherSDK.Config;
using CleverTap.WeatherSDK.ToastSystem;
namespace CleverTap.WeatherSDK.WeatherAPI
{
    public class WeatherManager
    {
        private static WeatherManager _instance;
        public static WeatherManager Instance => _instance ??= new WeatherManager();
        private IWeatherService _weatherService;
        public IWeatherService WeatherService => _weatherService;

        #region URL's
        private string weatherBaseURL = "https://api.open-meteo.com/v1/forecast?timezone=IST&current_weather=true&daily=temperature_2m_max";
        #endregion

        #region CACHE
        private float? _cachedTodayMaxTemp = null;
        private float? _cachedCurrentTemp = null;
        #endregion

        private WeatherManager()
        {
            var config = new Config.WeatherURLConfig(weatherBaseURL);
            _weatherService = new WeatherService(config);
        }
        #region PUBLIC API
        public async Task ShowTodayMaxTemperatureToast(float latitude, float longitude, bool useCache = true)
        {
            float temp = await GetTodayMaxTemperature(latitude, longitude, useCache);

            ToastService.Show($"Today Max Temp: {temp}°C");
        }
        public async Task ShowCurrentTemperatureToast(float latitude, float longitude, bool useCache = true)
        {
            float temp = await GetCurrentTemperature(latitude, longitude, useCache);

            ToastService.Show($"Current Temp: {temp}°C");
        }
        public async Task<float> GetTodayMaxTemperature(float latitude, float longitude, bool useCache = true)
        {
            if (useCache && _cachedTodayMaxTemp.HasValue)
                return _cachedTodayMaxTemp.Value;

            float temp = await _weatherService.GetTodayMaxTemperatureAsync(latitude, longitude);
            _cachedTodayMaxTemp = temp;
            return temp;
        }

        public async Task<float> GetCurrentTemperature(float latitude, float longitude, bool useCache = true)
        {
            if (useCache && _cachedCurrentTemp.HasValue)
                return _cachedCurrentTemp.Value;

            float temp = await _weatherService.GetCurrentTemperatureAsync(latitude, longitude);
            _cachedCurrentTemp = temp;
            return temp;
        }

        public void ClearCache()
        {
            _cachedTodayMaxTemp = null;
            _cachedCurrentTemp = null;
        }
        #endregion

    }
}
