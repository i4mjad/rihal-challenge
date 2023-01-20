using System;
namespace RihalChallenge.Domain.Entities;
public class Student
{
    public Guid Id { get; set; }
    public string Class { get; set; }
    public string Country { get; set; }
    public string Name { get; set; }
    public DateTime DayOfBirth { get; set; }

}


