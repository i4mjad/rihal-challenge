using Fluxor;

namespace RihalChallenge.Client.Store.Classes.GetClass;

public static class GetClassReducers
{
    [ReducerMethod]
    public static StateStore ReduceGetClassesAction(StateStore state, GetClassResultAction action)
    {
        return new StateStore(
            null,
            true,
            null,
            null,
            null
            ,null,null,null,null,null);
    }
    
    [ReducerMethod]
    public static StateStore ReduceGetClassSuccessAction(StateStore state, GetClassResultAction action) =>
        new StateStore(
            null,
            false,
            null,
            action.Class,
            state.Classes
            ,null,null,null,null,null);

} 