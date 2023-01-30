using Fluxor;

namespace RihalChallenge.Client.Store.Students.GetStudent;

public static class GetStudentReducers
{
    [ReducerMethod]
    public static StateStore ReduceGetStudentsAction(StateStore state, GetStudentResultAction action)
    {
        return new StateStore(
            null,
            true,
            null,
            null,
            null,null,null);
    }
    
    [ReducerMethod]
    public static StateStore ReduceGetStudentSuccessAction(StateStore state, GetStudentResultAction action) =>
        new StateStore(
            state.Students,
            false,
            action.Student,
            null,
            null,null,null);

} 