using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
namespace CleverTap.WeatherSDK.WeatherAPI
{
    public class WeatherService : IWeatherService
    {
        private const string BASE_URL =
            "https://api.open-meteo.com/v1/forecast?timezone=IST&current_weather=true&daily=temperature_2m_max";

        public async Task<float> GetCurrentTemperatureAsync(float lat, float lon)
        {
            string url = $"{BASE_URL}&latitude={lat}&longitude={lon}";
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
            string url = $"{BASE_URL}&latitude={lat}&longitude={lon}";
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
