using System.Text.Json;
using Fluxor;
using RihalChallenge.Client.Models.Classes;
using RihalChallenge.Client.Models.Countries;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Domain.UseCases.Countries.AddCountryUseCase;

namespace RihalChallenge.Client.Store.Countries.AddCountry;

public class AddCountryEffect: Effect<AddCountryAction>
{
    private readonly IAddCountryUseCase _addCountryUseCase;
    private readonly IBlazorPresenter<AddCountryResponse> _presenter;

    public AddCountryEffect(IAddCountryUseCase addCountryUseCase, IBlazorPresenter<AddCountryResponse> presenter)
    {
        _addCountryUseCase = addCountryUseCase;
        _presenter = presenter;
    }


    public override async Task HandleAsync(AddCountryAction action, IDispatcher dispatcher)
    {
        var request = new AddCountryRequest(action.Name);
        await _addCountryUseCase.Execute(request,_presenter);

        var responseJsonString = _presenter.GetJsonString();
        var addCountryClientResponse = JsonSerializer.Deserialize<AddCountryClientResponse>(responseJsonString);

        if (addCountryClientResponse is not null)
        {
            dispatcher.Dispatch(new AddCountryResultAction());
        }
    }
}