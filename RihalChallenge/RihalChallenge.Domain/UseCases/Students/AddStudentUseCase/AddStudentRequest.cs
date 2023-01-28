namespace RihalChallenge.Domain.UseCases.Students.AddStudentUseCase;

public record AddStudentRequest(string Name, string CountryId, string ClassId, DateTime DayOfBirth);