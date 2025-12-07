using NUnit.Framework;
using System.Threading.Tasks;
using CleverTap.WeatherSDK.WeatherAPI;
using System.Collections;
using UnityEngine.TestTools;
public class WeatherSDKPlayModeTests
{
    private MockWeatherService mockWeather;
    private MockToastService mockToast;

    [SetUp]
    public void Setup()
    {
        mockWeather = new MockWeatherService();
        mockToast = new MockToastService();

        // Reinitialize WeatherManager with mock services
        WeatherManager.Instance.Initialize(
            weatherService: mockWeather,
            toastService: mockToast
        );
    }

    [UnityTest]
    public IEnumerator ShowCurrentTemperatureToast_UsesMockWeatherService()
    {
        yield return WeatherManager.Instance.ShowCurrentTemperatureToast(12f, 77f).AsCoroutine();

        Assert.AreEqual(
            "Current Temp: 25°C",
            mockToast.LastMessage,
            "Toast should show mock temperature"
        );
    }

    [UnityTest]
    public IEnumerator ShowTodayMaxTemperatureToast_UsesMockWeatherService()
    {
        yield return WeatherManager.Instance.ShowTodayMaxTemperatureToast(12f, 77f).AsCoroutine();

        Assert.AreEqual(
            "Today Max Temp: 30°C",
            mockToast.LastMessage,
            "Toast should show mock max temperature"
        );
    }

    [UnityTest]
    public IEnumerator Cache_ShouldReturnSameValueWithoutCallingService()
    {
        // First call fills cache
        yield return WeatherManager.Instance.ShowTodayMaxTemperatureToast(10f, 20f).AsCoroutine();

        string firstMessage = mockToast.LastMessage;

        // Second call should come from cache
        yield return WeatherManager.Instance.ShowTodayMaxTemperatureToast(10f, 20f).AsCoroutine();

        string secondMessage = mockToast.LastMessage;

        Assert.AreEqual(firstMessage, secondMessage, "Cache should return same value");
    }
}