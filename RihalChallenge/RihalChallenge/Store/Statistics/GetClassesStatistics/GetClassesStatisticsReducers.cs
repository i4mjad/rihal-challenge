using Fluxor;

namespace RihalChallenge.Client.Store.Statistics.GetClassesStatistics;

public static class GetClassesStatisticsReducers
{
    [ReducerMethod]
    public static StateStore ReduceGetClassesAction(StateStore state, GetClassesStatisticsAction action)
    {
        return new StateStore(
            null,
            true,
            null,
            null,
            null
            ,null,
            null,
            null,
            null,
            null);
    }
    
    [ReducerMethod]
    public static StateStore ReduceGetClassSuccessAction(StateStore state, GetClassesStatisticsResultAction action) =>
        new StateStore(
            null,
            false,
            null,
            null,
            null,
            null,
            null,
            action.ClassesStatistics,
            null,
            null);

} 