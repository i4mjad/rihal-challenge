using Fluxor;

namespace RihalChallenge.Client.Store.Classes.UpdateClass;

public static class UpdateClassReducer
{
    [ReducerMethod]
    public static StateStore ReduceUpdateClassAction(StateStore state, UpdateClassAction action)
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
    public static StateStore ReduceUpdateClassResultAction(StateStore state, UpdateClassResultAction action)
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