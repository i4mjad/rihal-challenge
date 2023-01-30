using Fluxor;

namespace RihalChallenge.Client.Store.Classes.AddClass;

public static class AddClassReducer
{
    [ReducerMethod]
    public static StateStore ReduceAddClassAction(StateStore state, AddClassAction action)
    {
        return new StateStore(
            null,
            true,
            null,
            null,
            null
            ,null,null);
    }

    [ReducerMethod]
    public static StateStore ReduceAddClassResultAction(StateStore state, AddClassResultAction action)
    {
        return new StateStore(
            null,
            false,
            null,
            null,
            null
            ,null,null);
    }
}