using RihalChallenge.Domain.Entities;

namespace RihalChallenge.Domain.UseCases.Countries.DeleteCountryUseCase;

public record DeleteCountryResponse(IEnumerable<Country> Countries);