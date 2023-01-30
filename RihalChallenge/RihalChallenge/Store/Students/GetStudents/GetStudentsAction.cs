using RihalChallenge.Client.Models.Students;

namespace RihalChallenge.Client.Store.Students.GetStudents;

public class GetStudentsResultAction
{
    public IEnumerable<Student> Students { get; }

    public GetStudentsResultAction(IEnumerable<Student> students)
    {
        Students = students;
    }
}

public class GetStudentsAction{}