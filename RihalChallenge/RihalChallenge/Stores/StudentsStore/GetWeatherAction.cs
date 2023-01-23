using Fluxor;

namespace RihalChallenge.Client.Stores.StudentsStore;

public class GetWeatherAction
{
}

public static class Reducers
{
    [ReducerMethod]
    public static WeatherState ReduceGetStudentsAction(WeatherState state, GetWeatherAction action)
    {
        return new(weather: state.Weather);
    }
}


