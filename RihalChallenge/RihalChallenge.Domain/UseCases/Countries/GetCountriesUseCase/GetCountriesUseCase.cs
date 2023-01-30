using RihalChallenge.Domain.Repositories;

namespace RihalChallenge.Domain.UseCases.Countries.GetCountriesUseCase;

public class GetCountriesUseCase : IGetCountriesUseCase
{
    private readonly ICountriesRepository _countriesRepository;
    public GetCountriesUseCase(ICountriesRepository countriesRepository)
    {
        _countriesRepository = countriesRepository;
    }
    public async Task Execute(IPresenter<GetCountriesResponse> getCountriesPresenter)
    {
        var allCountries = await _countriesRepository.GetAllCountries();

        getCountriesPresenter.Success(new GetCountriesResponse(allCountries));
    }
}