namespace RihalChallenge.Client.Models;

public class Student
{
    public Guid Id { get; set; }
    public string StudentName { get; set; }
    public string ClassName { get; set; }
    public string CountryName { get; set; }
    public DateTime DayOfBirth { get; set; }
}