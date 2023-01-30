using System.Text.Json;
using Fluxor;
using RihalChallenge.Client.Models.Classes;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Domain.UseCases.Classes.DeleteClassUseCase;

namespace RihalChallenge.Client.Store.Classes.DeleteClass;

public class DeleteClassEffect: Effect<DeleteClassAction>
{
    private readonly IDeleteClassUseCase _deleteClassUseCase;
    private readonly IBlazorPresenter<DeleteClassResponse> _deleteClassPresenter;

    public DeleteClassEffect(IDeleteClassUseCase deleteClassUseCase, IBlazorPresenter<DeleteClassResponse> deleteClassPresenter)
    {
        _deleteClassUseCase = deleteClassUseCase;
        _deleteClassPresenter = deleteClassPresenter;
    }


    public override async Task HandleAsync(DeleteClassAction action, IDispatcher dispatcher)
    {
        var request = new DeleteClassRequest(action.Id);
        await _deleteClassUseCase.Execute(request, _deleteClassPresenter);

        var responseJsonString = _deleteClassPresenter.GetJsonString();
        var deleteClassClientResponse = JsonSerializer.Deserialize<DeleteClassClientResponse>(responseJsonString);

        if (deleteClassClientResponse is not null)
        {
            dispatcher.Dispatch(new DeleteClassResultAction(deleteClassClientResponse.Classes));
        }
    }
}