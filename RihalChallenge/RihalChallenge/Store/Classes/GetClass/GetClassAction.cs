using RihalChallenge.Client.Models.Classes;

namespace RihalChallenge.Client.Store.Classes.GetClass;

public class GetClassResultAction
{
    public Class Class { get; }

    public GetClassResultAction(Class studentsClass)
    {
        Class = studentsClass;
    }
}

public class GetClassAction
{
    public GetClassAction(Guid studentId)
    {
        ClassId = studentId;
    }

    public Guid ClassId { get; }
}