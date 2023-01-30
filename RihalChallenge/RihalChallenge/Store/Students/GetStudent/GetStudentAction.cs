using RihalChallenge.Client.Models.Students;

namespace RihalChallenge.Client.Store.Students.GetStudent;

public class GetStudentResultAction
{
    public Student Student { get; }

    public GetStudentResultAction(Student student)
    {
        Student = student;
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