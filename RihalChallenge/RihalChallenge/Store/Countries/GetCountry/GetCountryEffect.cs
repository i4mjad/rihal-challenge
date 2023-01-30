using System.Text.Json;
using Fluxor;
using RihalChallenge.Client.Models.Classes;
using RihalChallenge.Client.Models.Countries;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Domain.UseCases.Countries.GetCountryUseCase;

namespace RihalChallenge.Client.Store.Countries.GetCountry;

public class GetCountryEffect: Effect<GetCountryAction>
{
    private readonly IGetCountryUseCase _getClassUseCase;
    private readonly IBlazorPresenter<GetCountryResponse> _presenter;

    public GetCountryEffect(IGetCountryUseCase getClassUseCase, IBlazorPresenter<GetCountryResponse> presenter)
    {
        _getClassUseCase = getClassUseCase;
        _presenter = presenter;
    }

    public override async Task HandleAsync(GetCountryAction action, IDispatcher dispatcher)
    {
        var request = new GetCountryRequest(action.CountryId);
        await _getClassUseCase.Execute(request,_presenter);

        var responseJsonString = _presenter.GetJsonString();
        var getClassClientResponse = JsonSerializer.Deserialize<GetCountryClientResponse>(responseJsonString);

        if (getClassClientResponse != null)
        {
            dispatcher.Dispatch(new GetCountryResultAction(getClassClientResponse!.Country));
        }
    }
}