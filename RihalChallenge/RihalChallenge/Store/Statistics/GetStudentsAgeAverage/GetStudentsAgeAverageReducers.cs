using Fluxor;

namespace RihalChallenge.Client.Store.Statistics.GetStudentsAgeAverage;

public static class GetCountriesStatisticsReducers
{
    [ReducerMethod]
    public static StateStore ReduceGetClassesAction(StateStore state, GetStudentsAgeAverageAction action)
    {
        return new StateStore(
            null,
            true,
            null,
            null,
            null,
            null,
            null,
            state.ClassesStatistics,
            state.CountriesStatistics,
            null);
    }
    
    [ReducerMethod]
    public static StateStore ReduceGetClassSuccessAction(StateStore state, GetStudentsAgeAverageResultAction action) =>
        new StateStore(
            null,
            false,
            null,
            null,
            null,
            null,
            null,
            state.ClassesStatistics,
            state.CountriesStatistics,
            action.Average);

} 