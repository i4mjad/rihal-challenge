namespace RihalChallenge.Domain.Entities;

public class ClassStatistics
{
    public ClassStatistics(string className, string studentsNumber)
    {
        ClassName = className;
        StudentsNumber = studentsNumber;
    }

    public string ClassName { get; set; }
    public string StudentsNumber { get; set; }
}