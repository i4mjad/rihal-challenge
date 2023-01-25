using Fluxor;
using RihalChallenge.Client.Models;

namespace RihalChallenge.Client.Stores.StudentsStore;

[FeatureState]
public class StudentsState
{
    public StudentsState() { } // Required for creating initial state
    public GetStudentsClientResponse StudentsClientResponse { get; }
    
    
    public StudentsState(GetStudentsClientResponse studentsClientResponse)
    {
        StudentsClientResponse = studentsClientResponse;
    }
}