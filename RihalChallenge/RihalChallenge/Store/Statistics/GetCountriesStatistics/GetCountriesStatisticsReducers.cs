using Fluxor;

namespace RihalChallenge.Client.Store.Statistics.GetCountriesStatistics;

public static class GetCountriesStatisticsReducers
{
    [ReducerMethod]
    public static StateStore ReduceGetClassesAction(StateStore state, GetCountriesStatisticsAction action)
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
            null,
            null);
    }
    
    [ReducerMethod]
    public static StateStore ReduceGetClassSuccessAction(StateStore state, GetCountriesStatisticsResultAction action) =>
        new StateStore(
            null,
            false,
            null,
            null,
            null,
            null,
            null,
            state.ClassesStatistics,
            action.CountriesStatistics,
            null);

} 