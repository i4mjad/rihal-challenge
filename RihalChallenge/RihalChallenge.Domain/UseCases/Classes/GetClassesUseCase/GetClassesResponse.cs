using RihalChallenge.Domain.Entities;

namespace RihalChallenge.Domain.UseCases.Classes.GetClassesUseCase;

public record GetClassesResponse(IEnumerable<Class> Classes);