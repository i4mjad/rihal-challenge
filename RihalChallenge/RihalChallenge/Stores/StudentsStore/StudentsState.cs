using Fluxor;
using RihalChallenge.Client.Models;

namespace RihalChallenge.Client.Stores.StudentsStore;

[FeatureState]
public class StudentsState
{
    public StudentsState()
    {
        
    } // Required for creating initial state

    public IEnumerable<Student>? Students { get; } 
    public Student SelectedStudent { get; } 
    public bool? IsLoading { get; }



    public StudentsState(IEnumerable<Student>? students, bool? isLoading, Student selectedStudent)
    {
        Students = students;
        IsLoading = isLoading;
        SelectedStudent = selectedStudent;
    }
}