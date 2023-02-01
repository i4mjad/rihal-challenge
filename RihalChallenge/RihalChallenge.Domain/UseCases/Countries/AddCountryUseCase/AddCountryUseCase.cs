using RihalChallenge.Domain.Entities;
using RihalChallenge.Domain.Repositories;
namespace RihalChallenge.Domain.UseCases.Countries.AddCountryUseCase;

public class AddCountryUseCase : IAddCountryUseCase
{
    private readonly ICountriesRepository _countriesRepository;
    
    public AddCountryUseCase(ICountriesRepository countriesRepository)
    {
        _countriesRepository = countriesRepository;
    }
    
    public async Task Execute(AddCountryRequest request, IPresenter<AddCountryResponse> presenter)
    {
        var country = new Country()
        {
            Id = Guid.NewGuid(),
            CountryName = request.Name,
        };

        await _countriesRepository.AddCountry(country);
        presenter.Success(new AddCountryResponse(country.Id));


    }
}