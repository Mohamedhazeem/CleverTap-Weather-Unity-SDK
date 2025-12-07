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
        private IToastService _toastService;
        public IToastService ToastService => _toastService;

        #region CACHE
        private float? _cachedTodayMaxTemp = null;
        private float? _cachedCurrentTemp = null;
        #endregion

        private WeatherManager() { }

        private void EnsureInitialized()
        {
            if (_weatherService == null || _toastService == null)
                throw new System.Exception("WeatherManager not initialized. Call Initialize() first.");
        }
        #region PUBLIC API
        public void Initialize(IWeatherService weatherService = null, IToastService toastService = null)
        {
            // If app doesn’t provide services, use SDK defaults
            _weatherService = weatherService ?? new WeatherService(DefaultWeatherConfig.Default);

#if UNITY_ANDROID
            _toastService = toastService ?? new AndroidToastService();
#elif UNITY_IOS
            _toastService = toastService ?? new IOSToastService();
#else
            _toastService = toastService ?? new EditorToastService();
#endif
        }
        public void ShowMessageToast(string message)
        {
            EnsureInitialized();
            _toastService.Show(message);
        }
        public async Task ShowTodayMaxTemperatureToast(float latitude, float longitude, bool useCache = true)
        {
            float temp = await GetTodayMaxTemperature(latitude, longitude, useCache);
            EnsureInitialized();
            _toastService.Show($"Today Max Temp: {temp}°C");
        }
        public async Task ShowCurrentTemperatureToast(float latitude, float longitude, bool useCache = true)
        {
            float temp = await GetCurrentTemperature(latitude, longitude, useCache);
            EnsureInitialized();
            _toastService.Show($"Current Temp: {temp}°C");
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
