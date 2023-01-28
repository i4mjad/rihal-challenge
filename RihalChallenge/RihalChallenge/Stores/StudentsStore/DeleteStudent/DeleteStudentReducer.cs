using Fluxor;

namespace RihalChallenge.Client.Stores.StudentsStore;

public static class DeleteStudentReducer
{
    [ReducerMethod]
    public static StudentsState ReduceDeleteStudentAction(StudentsState state, DeleteStudentAction action)
    {
        return new StudentsState(state.Students,true,null);
    }

    [ReducerMethod]
    public static StudentsState ReduceDeleteStudentResultAction(StudentsState state, DeleteStudentResultAction action)
    {
        return new StudentsState(state.Students, false,null);
    }
}