namespace RihalChallenge.Domain.DataModels;
public class StudentDataModel
{
    public Guid Id { get; set; }
    public Guid ClassId { get; set; }
    public Guid CountryId { get; set; }
    public string Name { get; set; }
    public DateTime DayOfBirth { get; set; }

}


