using Fluxor;

namespace RihalChallenge.Client.Stores.StudentsStore.UpdateStudent;

public static class UpdateStudentReducer
{
    [ReducerMethod]
    public static StateStore ReduceUpdateStudentAction(StateStore state, UpdateStudentAction action)
    {
        return new StateStore(
            state.Students,
            true,
            null,
            null,
            null);
    }

    [ReducerMethod]
    public static StateStore ReduceUpdateStudentResultAction(StateStore state, UpdateStudentResultAction action)
    {
        return new StateStore(state.Students, false, null, null, null);
    }
}