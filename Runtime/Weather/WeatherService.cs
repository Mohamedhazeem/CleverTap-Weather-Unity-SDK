using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using CleverTap.WeatherSDK.Config;
namespace CleverTap.WeatherSDK.WeatherAPI
{
    public class WeatherService : IWeatherService
    {
        private readonly WeatherURLConfig _config;

        public WeatherService(WeatherURLConfig config)
        {
            _config = config;
        }

        public async Task<float> GetCurrentTemperatureAsync(float lat, float lon)
        {
            string url = $"{_config.BaseUrl}&latitude={lat}&longitude={lon}";
            UnityWebRequest request = UnityWebRequest.Get(url);

            var operation = request.SendWebRequest();
            while (!operation.isDone) await Task.Yield();

            if (request.result != UnityWebRequest.Result.Success)
                throw new System.Exception($"Weather API Error: {request.error}");

            string json = request.downloadHandler.text;
            Debug.Log("[WeatherSDK] API Response: " + json);

            WeatherResponse response = JsonUtility.FromJson<WeatherResponse>(json);

            if (response == null || response.current_weather == null)
                throw new System.Exception("Invalid weather API response");

            return response.current_weather.temperature;
        }

        public async Task<float> GetTodayMaxTemperatureAsync(float lat, float lon)
        {
            string url = $"{_config.BaseUrl}&latitude={lat}&longitude={lon}";
            UnityWebRequest request = UnityWebRequest.Get(url);

            var operation = request.SendWebRequest();
            while (!operation.isDone) await Task.Yield();

            if (request.result != UnityWebRequest.Result.Success)
                throw new System.Exception($"Weather API Error: {request.error}");

            string json = request.downloadHandler.text;

            WeatherResponse response = JsonUtility.FromJson<WeatherResponse>(json);

            if (response == null || response.daily == null || response.daily.temperature_2m_max.Length == 0)
                throw new System.Exception("Invalid weather API response");

            return response.daily.temperature_2m_max[0];
        }
    }
}
