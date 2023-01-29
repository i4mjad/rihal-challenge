using RihalChallenge.Domain.Entites;

namespace RihalChallenge.Domain.UseCases.Countries.DeleteCountryUseCase;

public record DeleteCountryResponse(IEnumerable<Country> Countries);