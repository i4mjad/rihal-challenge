using System.Text.Json;
using Fluxor;
using RihalChallenge.Client.Models;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Domain.UseCases.Students.DeleteStudentUseCase;

namespace RihalChallenge.Client.Stores.StudentsStore.DeleteStudent;

public class DeleteStudentEffect: Effect<DeleteStudentAction>
{
    private readonly IDeleteStudentUseCase _deleteStudentUseCase;
    private readonly IBlazorPresenter<DeleteStudentResponse> _deleteStudentPresenter;

    public DeleteStudentEffect(IDeleteStudentUseCase deleteStudentUseCase, IBlazorPresenter<DeleteStudentResponse> deleteStudentPresenter)
    {
        _deleteStudentUseCase = deleteStudentUseCase;
        _deleteStudentPresenter = deleteStudentPresenter;
    }


    public override async Task HandleAsync(DeleteStudentAction action, IDispatcher dispatcher)
    {
        var request = new DeleteStudentRequest(action.Id);
        await _deleteStudentUseCase.Execute(request, _deleteStudentPresenter);

        var responseJsonString = _deleteStudentPresenter.GetJsonString();
        var deleteStudentClientResponse = JsonSerializer.Deserialize<DeleteStudentClientResponse>(responseJsonString);

        if (deleteStudentClientResponse is not null)
        {
            dispatcher.Dispatch(new DeleteStudentResultAction(deleteStudentClientResponse.Students));
        }
    }
}