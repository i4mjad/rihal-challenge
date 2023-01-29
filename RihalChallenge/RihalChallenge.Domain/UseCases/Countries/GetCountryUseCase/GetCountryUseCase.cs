using RihalChallenge.Domain.Repositories;
using RihalChallenge.Domain.UseCases.Classes.GetStudentUseCase;

namespace RihalChallenge.Domain.UseCases.Countries.GetCountryUseCase;

public class GetCountryUseCase : IGetCountryUseCase
{
    private readonly ICountriesRepository _countriesRepository;
    public GetCountryUseCase(ICountriesRepository countriesRepository)
    {
        _countriesRepository = countriesRepository;
    }

    public async Task Execute(GetCountryRequest request, IPresenter<GetCountryResponse> presenter)
    {
        var country = await _countriesRepository.GetById(request.CountryId.ToString());
        presenter.Success(new GetCountryResponse(country));
    }
}
