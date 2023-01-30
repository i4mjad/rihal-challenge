using System.Text.Json;
using Fluxor;
using RihalChallenge.Client.Models.Classes;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Domain.UseCases.Classes.AddClassUseCase;

namespace RihalChallenge.Client.Store.Classes.AddClass;

public class AddClassEffect: Effect<AddClassAction>
{
    private readonly IAddClassUseCase _addClassUseCase;
    private readonly IBlazorPresenter<AddClassResponse> _presenter;

    public AddClassEffect(IAddClassUseCase addClassUseCase, IBlazorPresenter<AddClassResponse> presenter)
    {
        _addClassUseCase = addClassUseCase;
        _presenter = presenter;
    }


    public override async Task HandleAsync(AddClassAction action, IDispatcher dispatcher)
    {
        var request = new AddClassRequest(action.Name);
        await _addClassUseCase.Execute(request,_presenter);

        var responseJsonString = _presenter.GetJsonString();
        var addClassClientResponse = JsonSerializer.Deserialize<AddClassClientResponse>(responseJsonString);

        if (addClassClientResponse is not null)
        {
            dispatcher.Dispatch(new AddClassResultAction());
        }
    }
}