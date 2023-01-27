using System.Text.Json;
using Fluxor;
using RihalChallenge.Client.Models;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Domain.UseCases.Students.AddStudentUseCase;

namespace RihalChallenge.Client.Stores.StudentsStore.AddStudent;

public class AddStudentEffect: Effect<AddStudentAction>
{
    private readonly IAddStudentUseCase _addStudentUseCase;
    private readonly IBlazorPresenter<AddStudentResponse> _deleteStudentPresenter;

    public AddStudentEffect(IAddStudentUseCase addStudentUseCase, IBlazorPresenter<AddStudentResponse> deleteStudentPresenter)
    {
        _addStudentUseCase = addStudentUseCase;
        _deleteStudentPresenter = deleteStudentPresenter;
    }


    public override async Task HandleAsync(AddStudentAction action, IDispatcher dispatcher)
    {
        var request = new AddStudentRequest(action.Name, action.CountryId.ToString(), action.ClassId.ToString(),action.Dayofbirth);
        await _addStudentUseCase.Execute(request,_deleteStudentPresenter);

        var responseJsonString = _deleteStudentPresenter.GetJsonString();
        var deleteStudentClientResponse = JsonSerializer.Deserialize<DeleteStudentClientResponse>(responseJsonString);

        if (deleteStudentClientResponse is not null)
        {
            dispatcher.Dispatch(new AddStudentResultAction());
        }
    }
}