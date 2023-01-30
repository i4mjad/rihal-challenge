namespace RihalChallenge.Domain.Entities;

public class CountryStatistics
{
    public CountryStatistics(string countryName, string studentsNumber)
    {
        CountryName = countryName;
        StudentsNumber = studentsNumber;
    }

    public string CountryName { get; set; }
    public string StudentsNumber { get; set; }
}