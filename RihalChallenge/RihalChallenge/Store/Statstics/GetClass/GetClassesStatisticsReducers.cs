using Fluxor;

namespace RihalChallenge.Client.Store.Statstics.GetClass;

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
            null,null,null,null);
    }
    
    [ReducerMethod]
    public static StateStore ReduceGetClassSuccessAction(StateStore state, GetClassesStatisticsAction action) =>
        new StateStore(
            null,
            false,
            null,
            null,
            null
            ,null,null,null,null,null);

} 