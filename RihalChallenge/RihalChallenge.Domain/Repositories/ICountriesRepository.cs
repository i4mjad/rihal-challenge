using RihalChallenge.Domain.Entites;
using RihalChallenge.Domain.Entities;

namespace RihalChallenge.Domain.Repositories;

public interface ICountriesRepository
{
    public Task<IEnumerable<Country>> GetAllCountries();
    Task<Country> GetByName(string requestCountryName);
}