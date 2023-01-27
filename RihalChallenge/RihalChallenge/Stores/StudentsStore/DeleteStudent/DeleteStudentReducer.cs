using Fluxor;

namespace RihalChallenge.Client.Stores.StudentsStore;

public static class DeleteStudentReducer
{
    [ReducerMethod]
    public static StudentsState ReduceDeleteStudentAction(StudentsState state, DeleteStudentAction action)
    {
        return new StudentsState(state.Students,true);
    }

    [ReducerMethod]
    public static StudentsState ReduceDeleteStudentResultAction(StudentsState state, DeleteStudentResultAction action)
    {
        return new StudentsState(state.Students, false);
        //var updatedStudentsState = state.Classes.Where(x => x.Id != action.Id);
        //return new StudentsState(updatedStudentsState, false);
    }
}