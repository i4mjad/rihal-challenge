using Fluxor;

namespace RihalChallenge.Client.Stores.StudentsStore.AddStudent;

public static class AddStudentReducer
{
    [ReducerMethod]
    public static StateStore ReduceAddStudentAction(StateStore state, AddStudentAction action)
    {
        return new StateStore(state.Students,true, null,null,null);
    }

    [ReducerMethod]
    public static StateStore ReduceAddStudentResultAction(StateStore state, AddStudentResultAction action)
    {
        return new StateStore(state.Students, false, null,null,null);
    }
}