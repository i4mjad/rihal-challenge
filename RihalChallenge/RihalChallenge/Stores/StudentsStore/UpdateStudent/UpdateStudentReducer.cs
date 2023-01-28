using Fluxor;

namespace RihalChallenge.Client.Stores.StudentsStore.UpdateStudent;

public static class UpdateStudentReducer
{
    [ReducerMethod]
    public static StudentsState ReduceUpdateStudentAction(StudentsState state, UpdateStudentAction action)
    {
        return new StudentsState(state.Students,true, null);
    }

    [ReducerMethod]
    public static StudentsState ReduceUpdateStudentResultAction(StudentsState state, UpdateStudentResultAction action)
    {
        return new StudentsState(state.Students, false, null);
    }
}