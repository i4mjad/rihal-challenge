using RihalChallenge.Domain.Entites;
using RihalChallenge.Domain.Entities;

namespace RihalChallenge.Domain.Repositories;

public interface ICountriesRepository
{
    public Task<IEnumerable<Country>> GetAllCountries();
    Task<Country> GetById(string countryId);
    Task AddCountry(Country country);
    Task DeleteCountry(Guid countryId);
    Task UpdateCountry(Guid id, string newName);
}