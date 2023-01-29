using RihalChallenge.Domain.Repositories;

namespace RihalChallenge.Domain.UseCases.Countries.DeleteCountryUseCase;

public class DeleteCountryUseCase : IDeleteCountryUseCase
{
    private readonly ICountriesRepository _countriesRepository;

    
    public DeleteCountryUseCase(ICountriesRepository countriesRepository)
    {
        _countriesRepository = countriesRepository;
    }
    public async Task Execute(DeleteCountryRequest request, IPresenter<DeleteCountryResponse> presenter)
    {
        await _countriesRepository.DeleteCountry(request.CountryId);
        
        presenter.Success(new DeleteCountryResponse(await _countriesRepository.GetAllCountries()));
    }
}