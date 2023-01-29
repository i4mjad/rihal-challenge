using Fluxor;

namespace RihalChallenge.Client.Stores.ClassesStore.UpdateClass;

public static class UpdateClassReducer
{
    [ReducerMethod]
    public static ClassesState ReduceUpdateClassAction(ClassesState state, UpdateClassAction action)
    {
        return new ClassesState(state.Classes,true, null);
    }

    [ReducerMethod]
    public static ClassesState ReduceUpdateClassResultAction(ClassesState state, UpdateClassResultAction action)
    {
        return new ClassesState(state.Classes, false, null);
    }
}