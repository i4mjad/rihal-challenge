using RihalChallenge.Domain.Entites;
namespace RihalChallenge.Domain.UseCases.Classes.GetClassesUseCase;

public record GetClassesResponse(IEnumerable<Class> Classes);