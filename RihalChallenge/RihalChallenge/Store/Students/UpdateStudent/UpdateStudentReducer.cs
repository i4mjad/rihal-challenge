using Fluxor;

namespace RihalChallenge.Client.Store.Students.UpdateStudent;

public static class UpdateStudentReducer
{
    [ReducerMethod]
    public static StateStore ReduceUpdateStudentAction(StateStore state, UpdateStudentAction action)
    {
        return new StateStore(
            state.Students,
            true,
            state.SelectedStudent,
            null,
            state.Classes,
            state.Countries,
            null,
            null,
            null,
            null);
    }

    [ReducerMethod]
    public static StateStore ReduceUpdateStudentResultAction(StateStore state, UpdateStudentResultAction action)
    {
        return new StateStore(state.Students,
            false,
            state.SelectedStudent,
            null,
            state.Classes,
            state.Countries,
            null,
            null,
            null,
            null);
    }
}