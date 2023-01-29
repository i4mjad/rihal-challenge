using Fluxor;

namespace RihalChallenge.Client.Stores.ClassesStore.GetClasses;

public static class GetClassesReducers
{
    [ReducerMethod]
    public static ClassesState ReduceGetClassesAction(ClassesState state, GetClassesResultAction action)
    {
        return new ClassesState(isLoading:true, selectedClass:null, classes:null);
    }
    
    [ReducerMethod]
    public static ClassesState ReduceGetClassesSuccessAction(ClassesState state, GetClassesResultAction action) =>
        new ClassesState(isLoading: false, selectedClass:null, classes: action.Classes);

}