using Fluxor;
using RihalChallenge.Client.Models;

namespace RihalChallenge.Client.Stores.StudentsStore.AddStudent;

public class AddStudentAction
{
    public Guid CountryId { get; }
    public Guid ClassId { get; }

    public string Name { get; }

    public DateTime Dayofbirth { get; }

}
public class AddStudentResultAction
{
}

