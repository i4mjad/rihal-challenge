using Fluxor;
using RihalChallenge.Client.Models;
using RihalChallenge.Client.Models.Classes;

namespace RihalChallenge.Client.Stores.StudentsStore;

[FeatureState]
public class StateStore
{
    public StateStore()
    {
    } // Required for creating initial state

    public IEnumerable<Student>? Students { get; } 
    public Student? SelectedStudent { get; } 
    public bool? IsLoading { get; }
    
    public IEnumerable<Class>? Classes { get; } 
    public Class? SelectedClass { get; }



    public StateStore(IEnumerable<Student>? students, bool? isLoading, Student? selectedStudent, Class? selectedClass, IEnumerable<Class>? classes)
    {
        Students = students;
        IsLoading = isLoading;
        SelectedStudent = selectedStudent;
        SelectedClass = selectedClass;
        Classes = classes;
    }
}