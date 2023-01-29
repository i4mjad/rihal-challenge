using RihalChallenge.Client.Models.Classes;

namespace RihalChallenge.Client.Stores.ClassesStore.DeleteClass;

public class DeleteClassAction
{
    public Guid Id { get; }
    public DeleteClassAction(Guid id)
    {
        Id = id;
    }
}
public class DeleteClassResultAction
{
    public IEnumerable<Class> Classes { get; }
    public DeleteClassResultAction(IEnumerable<Class> classes)
    {
        Classes = classes;
    }
}

