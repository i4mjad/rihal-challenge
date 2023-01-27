using Fluxor;
using RihalChallenge.Client.Models;

namespace RihalChallenge.Client.Stores.ClassesStore;

[FeatureState]
public class ClassesState
{
    public ClassesState() { } // Required for creating initial state

    public IEnumerable<Class>? Classes { get; } 
    public bool? IsLoading { get; }



    public ClassesState(IEnumerable<Class>? classes, bool? isLoading)
    {
        Classes = classes;
        IsLoading = isLoading;
    }
}

public class Class
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}