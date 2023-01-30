using RihalChallenge.Domain.Entities;

namespace RihalChallenge.Domain.UseCases.Classes.DeleteClassUseCase;

public record DeleteClassResponse(IEnumerable<Class> Classes);