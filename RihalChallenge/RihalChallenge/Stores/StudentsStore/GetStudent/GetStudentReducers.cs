using Fluxor;

namespace RihalChallenge.Client.Stores.StudentsStore.GetStudents;

public static class GetStudentReducers
{
    [ReducerMethod]
    public static StudentsState ReduceGetStudentsAction(StudentsState state, GetStudentResultAction action)
    {
        return new StudentsState(isLoading:true, students:null, selectedStudent:null);
    }
    
    [ReducerMethod]
    public static StudentsState ReduceGetStudentSuccessAction(StudentsState state, GetStudentResultAction action) =>
        new StudentsState(isLoading: false, students: null, selectedStudent:action.Students);

} 