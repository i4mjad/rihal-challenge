using RihalChallenge.Domain.Entities;

namespace RihalChallenge.Domain.UseCases.Students.DeleteStudentUseCase;

public record DeleteStudentResponse(IEnumerable<Student> Students);