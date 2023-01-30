using System.Diagnostics.CodeAnalysis;
using Fluxor;

namespace RihalChallenge.Client.Store.Students.AddStudent;

public static class AddStudentReducer
{
    [ReducerMethod]
    public static StateStore ReduceAddStudentAction(StateStore state, AddStudentAction action)
    {
        return new StateStore(state.Students,true, null,null,state.Classes,state.Countries,null,null,null,null);
    }

    [ReducerMethod]
    public static StateStore ReduceAddStudentResultAction(StateStore state, AddStudentResultAction action)
    {
        return new StateStore(state.Students, false, null,null,state.Classes,state.Countries,null,null,null,null);
    }
}