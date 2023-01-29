using Fluxor;
using RihalChallenge.Client.Models;
using RihalChallenge.Client.Models.Classes;

namespace RihalChallenge.Client.Stores.ClassesStore;

[FeatureState]
public class ClassesState
{
    public ClassesState()
    {
    } // Required for creating initial state

    public IEnumerable<Class>? Classes { get; } 
    public Class SelectedClass { get; }
    public bool? IsLoading { get; }



    public ClassesState(IEnumerable<Class>? classes, bool? isLoading, Class selectedClass)
    {
        Classes = classes;
        IsLoading = isLoading;
        SelectedClass = selectedClass;
    }
}

