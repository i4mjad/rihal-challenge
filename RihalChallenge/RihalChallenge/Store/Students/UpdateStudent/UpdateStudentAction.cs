using Fluxor;
using RihalChallenge.Client.Models;

namespace RihalChallenge.Client.Stores.StudentsStore.UpdateStudent;

public class UpdateStudentAction
{
    public UpdateStudentAction(Guid studentId, Guid countryId, Guid classId, string name, DateTime dayofBirth)
    {
        StudentId = studentId;
        CountryId = countryId;
        ClassId = classId;
        Name = name;
        DayofBirth = dayofBirth;
    }

    public Guid CountryId { get; }
    public Guid StudentId { get; }
    public Guid ClassId { get; }

    public string Name { get; }

    public DateTime DayofBirth { get; }

}
public class UpdateStudentResultAction
{
}

