using Fluxor;
using RihalChallenge.Client.Stores.StudentsStore;

namespace RihalChallenge.Client.Stores.ClassesStore.GetClasses;

public static class GetClassesReducers
{
    [ReducerMethod]
    public static StateStore ReduceGetClassesAction(StateStore state, GetClassesResultAction action)
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
    public static StateStore ReduceGetClassesSuccessAction(StateStore state, GetClassesResultAction action) =>
        new StateStore(
            null,
            false,
            null,
            null,
            action.Classes
            );

}