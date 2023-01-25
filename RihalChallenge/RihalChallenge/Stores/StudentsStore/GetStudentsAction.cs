using Fluxor;
using RihalChallenge.Client.Models;

namespace RihalChallenge.Client.Stores.StudentsStore;

public class GetStudentsResultAction
{
    public IEnumerable<Student> Forecasts { get; }

    public GetStudentsResultAction(IEnumerable<Student> students)
    {
        Forecasts = students;
    }
}

public class GetStudentsAction{}

public static class Reducers
{
    [ReducerMethod]
    public static StudentsState ReduceGetStudentsAction(StudentsState state, GetStudentsResultAction action)
    {
        return new (new GetStudentsClientResponse(action.Forecasts));
    }
}


