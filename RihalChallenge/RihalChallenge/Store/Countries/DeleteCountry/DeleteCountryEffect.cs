using System.Text.Json;
using Fluxor;
using RihalChallenge.Client.Models.Countries;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Domain.UseCases.Countries.DeleteCountryUseCase;

namespace RihalChallenge.Client.Store.Countries.DeleteCountry;

public class DeleteCountryEffect: Effect<DeleteCountryAction>
{
    private readonly IDeleteCountryUseCase _deleteClassUseCase;
    private readonly IBlazorPresenter<DeleteCountryResponse> _deleteClassPresenter;

    public DeleteCountryEffect(IDeleteCountryUseCase deleteClassUseCase, IBlazorPresenter<DeleteCountryResponse> deleteClassPresenter)
    {
        _deleteClassUseCase = deleteClassUseCase;
        _deleteClassPresenter = deleteClassPresenter;
    }


    public override async Task HandleAsync(DeleteCountryAction action, IDispatcher dispatcher)
    {
        var request = new DeleteCountryRequest(action.Id);
        await _deleteClassUseCase.Execute(request, _deleteClassPresenter);

        var responseJsonString = _deleteClassPresenter.GetJsonString();
        var deleteCountryClientResponse = JsonSerializer.Deserialize<DeleteCountryClientResponse>(responseJsonString);

        if (deleteCountryClientResponse is not null)
        {
            dispatcher.Dispatch(new DeleteCountryResultAction(deleteCountryClientResponse.Countries));
        }
    }
}