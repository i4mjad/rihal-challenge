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

    public Task<Country> GetById(string countryId)
    {
        
            var countriesDataModels = _inMemoryDataSource.CountryDataSet().GetAll();
            var countryDataModel = countriesDataModels.First(x => x.Id == Guid.Parse(countryId));
            var country = new Country()
            {
                Id = countryDataModel.Id,
                Name = countryDataModel.Name
            };
            return Task.FromResult(country);
        
    }

    public Task AddCountry(Country country)
    {
        _inMemoryDataSource.CountryDataSet().Add(new CountryDataModel()
        {
            Id = country.Id,
            Name = country.Name
        });

        return Task.CompletedTask;
    }

    public Task DeleteCountry(Guid countryId)
    {
        var getAllCountries = _inMemoryDataSource.CountryDataSet().GetAll();
        var countryDataModel = getAllCountries.First(x => x.Id == countryId);
        _inMemoryDataSource.CountryDataSet().Delete(countryDataModel);
        
        return Task.CompletedTask;
    }

    public Task UpdateCountry(Guid id, string newName)
    {
        var countriesDataModels = _inMemoryDataSource.CountryDataSet().GetAll();
        var currentCountry = countriesDataModels.FirstOrDefault(x => x.Id == id);
        var updatedCountry = new CountryDataModel()
        {
            Id = id,
            Name = newName,
        };

        _inMemoryDataSource.CountryDataSet().Update(currentCountry!,updatedCountry);
        return Task.CompletedTask;
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