using Fluxor;

namespace RihalChallenge.Client.Stores.ClassesStore.AddClass;

public static class AddClassReducer
{
    [ReducerMethod]
    public static ClassesState ReduceAddClassAction(ClassesState state, AddClassAction action)
    {
        return new ClassesState(state.Classes,true, null);
    }

    [ReducerMethod]
    public static ClassesState ReduceAddClassResultAction(ClassesState state, AddClassResultAction action)
    {
        return new ClassesState(state.Classes, false, null);
    }
}