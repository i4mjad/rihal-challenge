using System.Text.Json;
using Fluxor;
using RihalChallenge.Client.Models.Classes;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Domain.UseCases.Classes.UpdateStudentUseCase;

namespace RihalChallenge.Client.Store.Classes.UpdateClass;

public class UpdateClassEffect: Effect<UpdateClassAction>
{
    private readonly IUpdateClassUseCase _addClassUseCase;
    private readonly IBlazorPresenter<UpdateClassResponse> _updateClassPresenter;

    public UpdateClassEffect(IUpdateClassUseCase addClassUseCase, IBlazorPresenter<UpdateClassResponse> updateClassPresenter)
    {
        _addClassUseCase = addClassUseCase;
        _updateClassPresenter = updateClassPresenter;
    }


    public override async Task HandleAsync(UpdateClassAction action, IDispatcher dispatcher)
    {
        var request = new UpdateClassRequest(action.ClassId, action.Name);
        await _addClassUseCase.Execute(request,_updateClassPresenter);

        var responseJsonString = _updateClassPresenter.GetJsonString();
        var deleteClassClientResponse = JsonSerializer.Deserialize<UpdateClassClientResponse>(responseJsonString);

        if (deleteClassClientResponse is not null)
        {
            dispatcher.Dispatch(new UpdateClassResultAction());
        }
    }
}