using Fluxor;
using RihalChallenge.Client.Stores.StudentsStore;

namespace RihalChallenge.Client.Stores.ClassesStore.DeleteClass;

public static class DeleteClassReducer
{
    [ReducerMethod]
    public static StateStore ReduceDeleteClassAction(StateStore state, DeleteClassAction action)
    {
        return new StateStore(
            null,
            true,
            null,
            null,
            null
            );
    }

    [ReducerMethod]
    public static StateStore ReduceDeleteClassResultAction(StateStore state, DeleteClassResultAction action)
    {
        return new StateStore(
            null,
            false,
            null,
            null,
            action.Classes
            );
    }
}