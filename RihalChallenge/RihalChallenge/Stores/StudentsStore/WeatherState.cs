using Fluxor;
using RihalChallenge.Data;

namespace RihalChallenge.Client.Stores.StudentsStore;

[FeatureState]
public class WeatherState
{
    public WeatherState() { } // Required for creating initial state
    public WeatherForecast[] Weather { get; } = new[] {
        new WeatherForecast()
        {
            Date = DateTime.Now,
            TemperatureC = 30,
            Summary = "Good"
        },
        new WeatherForecast()
        {
            Date = DateTime.Now,
            TemperatureC = 35,
            Summary = "Good"
        },
        
        
    };
    
    public WeatherState(WeatherForecast[] weather)
    {

        Weather = weather;
    }
}