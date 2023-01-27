using Fluxor;

namespace RihalChallenge.Client.Stores.StudentsStore.AddStudent;

public static class AddStudentReducer
{
    [ReducerMethod]
    public static StudentsState ReduceAddStudentAction(StudentsState state, AddStudentAction action)
    {
        return new StudentsState(state.Students,true);
    }

    [ReducerMethod]
    public static StudentsState ReduceAddStudentResultAction(StudentsState state, AddStudentResultAction action)
    {
        return new StudentsState(state.Students, false);
    }
}