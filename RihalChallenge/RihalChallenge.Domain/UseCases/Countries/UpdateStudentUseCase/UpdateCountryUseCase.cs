using RihalChallenge.Domain.Repositories;

namespace RihalChallenge.Domain.UseCases.Countries.UpdateStudentUseCase;

public class UpdateCountryUseCase : IUpdateCountryUseCase
{
    private readonly ICountriesRepository _countriesRepository;
    
    public UpdateCountryUseCase(ICountriesRepository countriesRepository)
    {
        _countriesRepository = countriesRepository;
    }
    public async Task Execute(UpdateCountryRequest request, IPresenter<UpdateCountryResponse> updateClassPresenter)
    {
        var student = await _countriesRepository.GetById(request.Id.ToString());
        await _countriesRepository.UpdateCountry(request.Id, request.NewName);

        updateClassPresenter.Success(new UpdateCountryResponse(request.Id));
    }
}