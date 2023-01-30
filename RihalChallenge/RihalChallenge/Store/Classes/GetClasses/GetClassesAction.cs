
using RihalChallenge.Client.Models.Classes;

namespace RihalChallenge.Client.Store.Classes.GetClasses;


public class GetClassesAction { }

public class GetClassesResultAction
{
    public IEnumerable<Class> Classes { get; }

    public GetClassesResultAction(IEnumerable<Class> classes)
    {
        Classes = classes;
    }
}

