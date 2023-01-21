using RihalChallenge.Domain.Entities;

namespace RihalChallenge.Domain.UseCases.Students.AddStudentUseCase;

public record AddStudentRequest(string name, string countryName, string className);