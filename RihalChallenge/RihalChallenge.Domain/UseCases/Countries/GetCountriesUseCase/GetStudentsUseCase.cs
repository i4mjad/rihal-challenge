using RihalChallenge.Domain.Repositories;
using RihalRihalChallenge.Domain.UseCases.Countries.GetCountriesUseCase;

namespace RihalChallenge.Domain.UseCases.Countries.GetCountriesUseCase;

public class GetCountriesUseCase : IGetCountriesUseCase
{
    private readonly ICountriesRepository _countriesRepository;
    public GetCountriesUseCase(ICountriesRepository countriesRepository)
    {
        _countriesRepository = countriesRepository;
    }
    public async Task Execute(IGetCountriesPresenter getCountriesPresenter)
    {
        var allCountries = await _countriesRepository.GetAllCountries();

        getCountriesPresenter.Success(new GetCountriesResponse(allCountries));
    }
}