using System.Text.Json;
using Fluxor;
using RihalChallenge.Client.Models.Countries;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Domain.UseCases.Countries.GetCountriesUseCase;
using RihalChallenge.Domain.UseCases.Students.DeleteStudentUseCase;

namespace RihalChallenge.Client.Store.Countries.GetCountries;

public class GetCountriesEffect: Effect<GetCountriesAction>
{
    private readonly IGetCountriesUseCase _getCountriesUseCase;
    private readonly IBlazorPresenter<GetCountriesResponse> _getCountriesPresenter;

    public GetCountriesEffect(IGetCountriesUseCase getCountriesUseCase, IBlazorPresenter<GetCountriesResponse> getCountriesPresenter, IDeleteStudentUseCase deleteStudentUseCase)
    {
        _getCountriesUseCase = getCountriesUseCase;
        _getCountriesPresenter = getCountriesPresenter;
    }

    public override async Task HandleAsync(GetCountriesAction action, IDispatcher dispatcher)
    {
        await _getCountriesUseCase.Execute(_getCountriesPresenter);

        var responseJsonString = _getCountriesPresenter.GetJsonString();
        var getCountriesClientResponse = JsonSerializer.Deserialize<GetCountriesClientResponse>(responseJsonString);

        if (getCountriesClientResponse != null)
        {
            dispatcher.Dispatch(new GetCountriesResultAction(getCountriesClientResponse!.Countries));
        }
    }
}