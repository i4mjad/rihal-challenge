using Fluxor;

namespace RihalChallenge.Client.Store.Classes.GetClasses;

public static class GetClassesReducers
{
    [ReducerMethod]
    public static StateStore ReduceGetClassesAction(StateStore state, GetClassesAction action)
    {
        return new StateStore(
            null,
            true,
            state.SelectedStudent,
            null,
            null,
            null,
            null,
            null,
            null,
            null);
    }
    
    [ReducerMethod]
    public static StateStore ReduceGetClassesSuccessAction(StateStore state, GetClassesResultAction action) =>
        new StateStore(
            null,
            false,
            state.SelectedStudent,
            null,
            action.Classes,
            null,
            null,null,null,null);

}