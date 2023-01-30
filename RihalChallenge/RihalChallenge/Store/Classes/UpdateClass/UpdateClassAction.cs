namespace RihalChallenge.Client.Store.Classes.UpdateClass;

public class UpdateClassAction
{
    public UpdateClassAction(Guid classId, string name)
    {
        ClassId = classId;
        Name = name;
    }

    public Guid ClassId { get; }

    public string Name { get; }
}
public class UpdateClassResultAction
{
}

