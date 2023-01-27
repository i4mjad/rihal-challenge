using RihalChallenge.Client.Stores.ClassesStore;
using RihalChallenge.Client.Stores.Countries;

namespace RihalChallenge.Client.Models;

public record GetCountriesClientResponse(IEnumerable<Country> Countries);