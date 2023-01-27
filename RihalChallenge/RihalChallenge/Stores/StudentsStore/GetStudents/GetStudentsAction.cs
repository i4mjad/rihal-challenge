using RihalChallenge.Client.Models;

namespace RihalChallenge.Client.Stores.StudentsStore;

public class GetStudentsResultAction
{
    public IEnumerable<Student> Students { get; }

    public GetStudentsResultAction(IEnumerable<Student> students)
    {
        Students = students;
    }
}

public class GetStudentsAction{}