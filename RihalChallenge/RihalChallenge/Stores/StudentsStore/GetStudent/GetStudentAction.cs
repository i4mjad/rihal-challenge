using RihalChallenge.Client.Models;

namespace RihalChallenge.Client.Stores.StudentsStore;

public class GetStudentResultAction
{
    public Student Students { get; }

    public GetStudentResultAction(Student student)
    {
        Students = student;
    }
}

public class GetStudentAction
{
    public GetStudentAction(Guid studentId)
    {
        StudentId = studentId;
    }

    public Guid StudentId { get; }
}