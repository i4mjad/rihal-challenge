using Fluxor;
using RihalChallenge.Client.Stores.ClassesStore;

namespace RihalChallenge.Client.Stores.ClassesStore.GetClass;

public static class GetClassReducers
{
    [ReducerMethod]
    public static ClassesState ReduceGetClassesAction(ClassesState state, GetClassResultAction action)
    {
        return new ClassesState(isLoading:true, classes:null, selectedClass:null);
    }
    
    [ReducerMethod]
    public static ClassesState ReduceGetClassSuccessAction(ClassesState state, GetClassResultAction action) =>
        new ClassesState(isLoading: false, classes: null, selectedClass:action.Class);

} 