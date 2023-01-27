using RihalChallenge.Client.Models;

namespace RihalChallenge.Client.Stores.ClassesStore.GetClasses;


public class GetClassesAction { }

public class GetClassesResultAction
{
    public IEnumerable<Class> Classes { get; }

    public GetClassesResultAction(IEnumerable<Class> students)
    {
        Classes = students;
    }
}

