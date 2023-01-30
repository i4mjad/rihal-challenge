namespace RihalChallenge.Domain.Utilities;

public static class AgeCalculator
{
    public static int GetAge(DateTime dayOfBirth)
    {
        // Save today's date.
        var today = DateTime.Today;

        // Calculate the age.
        var age = today.Year - dayOfBirth.Year;

        // Go back to the year in which the person was born in case of a leap year
        if (dayOfBirth.Date > today.AddYears(-age)) age--;
        return age;
    }
}