using Fluxor;

namespace RihalChallenge.Client.Stores.ClassesStore.DeleteClass;

public static class DeleteClassReducer
{
    [ReducerMethod]
    public static ClassesState ReduceDeleteClassAction(ClassesState state, DeleteClassAction action)
    {
        return new ClassesState(state.Classes,true,null);
    }

    [ReducerMethod]
    public static ClassesState ReduceDeleteClassResultAction(ClassesState state, DeleteClassResultAction action)
    {
        return new ClassesState(action.Classes, false,null);
    }
}