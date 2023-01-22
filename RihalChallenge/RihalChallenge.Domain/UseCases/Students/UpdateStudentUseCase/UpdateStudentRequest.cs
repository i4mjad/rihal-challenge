namespace RihalChallenge.Domain.UseCases.Students.UpdateStudentUseCase;

public record UpdateStudentRequest(Guid Id, string NewName, string NewCountryId, string NewClassId);