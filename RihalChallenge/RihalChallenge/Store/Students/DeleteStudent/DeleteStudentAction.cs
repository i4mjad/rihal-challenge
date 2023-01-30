using RihalChallenge.Client.Models.Students;

namespace RihalChallenge.Client.Store.Students.DeleteStudent;

public class DeleteStudentAction
{
    public Guid Id { get; }
    public DeleteStudentAction(Guid id)
    {
        Id = id;
    }
}
public class DeleteStudentResultAction
{
    public IEnumerable<Student> Students { get; }
    public DeleteStudentResultAction(IEnumerable<Student> students)
    {
        Students = students;
    }
}

