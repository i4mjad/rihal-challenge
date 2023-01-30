using Fluxor;

namespace RihalChallenge.Client.Store.Students.GetStudents;

public static class GetStudentsReducers
{
    [ReducerMethod]
    public static StateStore ReduceGetStudentsAction(StateStore state, GetStudentsAction action)
    {
        return new StateStore(
            null,
            true,
            null,
            null,
            null,null,null);
    }
    
    [ReducerMethod]
    public static StateStore ReduceGetStudentsSuccessAction(StateStore state, GetStudentsResultAction action) =>
        new StateStore(
            action.Students,
            false,
            null,
            null,
            null,null,null);

}