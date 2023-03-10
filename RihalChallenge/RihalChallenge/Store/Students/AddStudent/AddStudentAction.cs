namespace RihalChallenge.Client.Store.Students.AddStudent;

public class AddStudentAction
{
    public AddStudentAction(Guid countryId, Guid classId, string name, DateTime dayofBirth)
    {
        CountryId = countryId;
        ClassId = classId;
        Name = name;
        DayofBirth = dayofBirth;
    }

    public Guid CountryId { get; }
    public Guid ClassId { get; }

    public string Name { get; }

    public DateTime DayofBirth { get; }

}
public class AddStudentResultAction
{
}

