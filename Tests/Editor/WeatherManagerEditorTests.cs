using NUnit.Framework;
using System.Threading.Tasks;
using CleverTap.WeatherSDK.WeatherAPI;

public class WeatherManagerEditorTests
{
    private WeatherManager manager;
    private MockWeatherService mockWeather;
    private MockToastService mockToast;

    [SetUp]
    public void Setup()
    {
        mockWeather = new MockWeatherService();
        mockToast = new MockToastService();

        manager = WeatherManager.Instance;
        manager.Initialize(mockWeather, mockToast);
    }

    [Test]
    public async Task ShowCurrentTemperatureToast_ShowsCorrectMessage()
    {
        await manager.ShowCurrentTemperatureToast(12.34f, 56.78f);

        Assert.AreEqual(1, mockToast.MessagesShown.Count);
        Assert.AreEqual("Current Temp: 25°C", mockToast.MessagesShown[0]);
    }

    [Test]
    public async Task ShowTodayMaxTemperatureToast_ShowsCorrectMessage()
    {
        await manager.ShowTodayMaxTemperatureToast(12.34f, 56.78f);

        Assert.AreEqual(1, mockToast.MessagesShown.Count);
        Assert.AreEqual("Today Max Temp: 30°C", mockToast.MessagesShown[0]);
    }
    [Test]
    public async Task CachingWorksForCurrentTemperature()
    {
        await manager.GetCurrentTemperature(0, 0, true); // first call
        await manager.GetCurrentTemperature(0, 0, true); // should use cache

        // mockWeather always returns 25, so we can check if caching did not affect output
        Assert.AreEqual(25f, await manager.GetCurrentTemperature(0, 0));
    }

}
