using RihalChallenge.Domain.Entities;

namespace RihalChallenge.Domain.UseCases.Countries.GetCountriesUseCase;

public record GetCountriesResponse(IEnumerable<Country> Countries);