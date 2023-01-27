using Fluxor;

namespace RihalChallenge.Client.Stores.ClassesStore.GetClasses;

public static class GetClassesReducers
{
    [ReducerMethod]
    public static ClassesState ReduceGetClassesAction(ClassesState state, GetClassesResultAction action)
    {
        return new ClassesState(isLoading:true, classes:null);
    }
    
    [ReducerMethod]
    public static ClassesState ReduceGetClassesSuccessAction(ClassesState state, GetClassesResultAction action) =>
        new ClassesState(isLoading: false, classes: action.Classes);

}