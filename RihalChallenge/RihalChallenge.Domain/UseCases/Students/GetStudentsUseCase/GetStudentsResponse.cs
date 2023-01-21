using RihalChallenge.Domain.Entities;

namespace RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;

public record GetStudentsResponse(IEnumerable<Student> Students);