using RihalChallenge.Domain.Entites;

namespace RihalChallenge.Domain.UseCases.Countries.GetCountriesUseCase;

public record GetCountriesResponse(IEnumerable<Country> Countries);