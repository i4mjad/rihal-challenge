using RihalChallenge.Domain.DataModels;
using RihalChallenge.Domain.DataSources;
using RihalChallenge.Domain.Entites;

namespace RihalChallenge.Domain.Repositories.InMemory;

public class InMemoryCountriesRepository: ICountriesRepository
{
    private readonly IInMemoryDataSource _inMemoryDataSource;

    public InMemoryCountriesRepository(IInMemoryDataSource inMemoryDataSource)
    {
        _inMemoryDataSource = inMemoryDataSource;
    }
    public Task<IEnumerable<Country>> GetAllCountries()
    {
        var allStudentsDataModel = _inMemoryDataSource.CountryDataSet().GetAll();

        return Task.FromResult(allStudentsDataModel.Select(GetCountriesFromDataModel));
    }

    public Task<Country> GetByName(string requestCountryName)
    {
        var countryDataModel = _inMemoryDataSource.CountryDataSet().GetAll().First(x => x.Name == requestCountryName);
        var model = new Country()
        {
            Id = countryDataModel.Id,
            Name = countryDataModel.Name
        };
        return Task.FromResult(model);
    }

    private Country GetCountriesFromDataModel(CountryDataModel countryDataModel)
    {
        return new Country()
        {
            Id = countryDataModel.Id,
            Name = countryDataModel.Name
        };
    }
}