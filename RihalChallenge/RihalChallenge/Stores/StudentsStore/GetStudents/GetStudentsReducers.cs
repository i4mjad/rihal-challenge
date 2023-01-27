using Fluxor;

namespace RihalChallenge.Client.Stores.StudentsStore.GetStudents;

public static class GetStudentsReducers
{
    [ReducerMethod]
    public static StudentsState ReduceGetStudentsAction(StudentsState state, GetStudentsResultAction action)
    {
        return new StudentsState(isLoading:true, students:null);
    }
    
    [ReducerMethod]
    public static StudentsState ReduceGetStudentsSuccessAction(StudentsState state, GetStudentsResultAction action) =>
        new StudentsState(isLoading: false, students: action.Students);

}