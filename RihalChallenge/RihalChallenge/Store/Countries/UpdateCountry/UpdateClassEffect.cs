using System.Text.Json;
using Fluxor;
using RihalChallenge.Client.Models.Countries;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Domain.UseCases.Countries.UpdateStudentUseCase;

namespace RihalChallenge.Client.Store.Countries.UpdateCountry;

public class UpdateCountryEffect: Effect<UpdateCountryAction>
{
    private readonly IUpdateCountryUseCase _addClassUseCase;
    private readonly IBlazorPresenter<UpdateCountryResponse> _updateClassPresenter;

    public UpdateCountryEffect(IUpdateCountryUseCase addClassUseCase, IBlazorPresenter<UpdateCountryResponse> updateClassPresenter)
    {
        _addClassUseCase = addClassUseCase;
        _updateClassPresenter = updateClassPresenter;
    }


    public override async Task HandleAsync(UpdateCountryAction action, IDispatcher dispatcher)
    {
        var request = new UpdateCountryRequest(action.CountryId, action.Name);
        await _addClassUseCase.Execute(request,_updateClassPresenter);

        var responseJsonString = _updateClassPresenter.GetJsonString();
        var deleteClassClientResponse = JsonSerializer.Deserialize<UpdateCountryClientResponse>(responseJsonString);

        if (deleteClassClientResponse is not null)
        {
            dispatcher.Dispatch(new UpdateCountryResultAction());
        }
    }
}