using System;
using RihalChallenge.Domain.Utilities;

namespace RihalChallenge.Domain.Entities;
public class Student
{
    public Guid Id { get; set; }
    public string StudentName { get; set; }
    public string ClassName { get; set; }
    public string CountryName { get; set; }
    public DateTime DayOfBirth { get; set; }

    public int Age => AgeCalculator.GetAge(DayOfBirth);

}


