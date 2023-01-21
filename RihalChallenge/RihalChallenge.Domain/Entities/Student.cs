using System;
using RihalChallenge.Domain.Entites;

namespace RihalChallenge.Domain.Entities;
public class Student
{
    public Guid Id { get; set; }
    public string StudentName { get; set; }
    public Class Class { get; set; }
    public Country Country { get; set; }
    public DateTime DayOfBirth { get; set; }

}


