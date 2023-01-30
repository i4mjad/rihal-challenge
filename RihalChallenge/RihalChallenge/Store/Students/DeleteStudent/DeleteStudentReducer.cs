using Fluxor;

namespace RihalChallenge.Client.Stores.StudentsStore.DeleteStudent;

public static class DeleteStudentReducer
{
    [ReducerMethod]
    public static StateStore ReduceDeleteStudentAction(StateStore state, DeleteStudentAction action)
    {
        return new StateStore(state.Students,true,null,null,null);
    }

    [ReducerMethod]
    public static StateStore ReduceDeleteStudentResultAction(StateStore state, DeleteStudentResultAction action)
    {
        return new StateStore(action.Students, false,null,null,null);
    }
}