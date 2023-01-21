using RihalChallenge.Domain.Entities;

namespace RihalChallenge.Domain.UseCases.GetStudentsUseCase;

public record GetStudentsResponse(IEnumerable<Student> Students);