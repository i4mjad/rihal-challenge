using System.Text.Json;
using Fluxor;
using RihalChallenge.Client.Models.Students;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Domain.UseCases.Students.UpdateStudentUseCase;

namespace RihalChallenge.Client.Stores.StudentsStore.UpdateStudent;

public class UpdateStudentEffect: Effect<UpdateStudentAction>
{
    private readonly IUpdateStudentUseCase _addStudentUseCase;
    private readonly IBlazorPresenter<UpdateStudentResponse> _updateStudentPresenter;

    public UpdateStudentEffect(IUpdateStudentUseCase addStudentUseCase, IBlazorPresenter<UpdateStudentResponse> updateStudentPresenter)
    {
        _addStudentUseCase = addStudentUseCase;
        _updateStudentPresenter = updateStudentPresenter;
    }


    public override async Task HandleAsync(UpdateStudentAction action, IDispatcher dispatcher)
    {
        var request = new UpdateStudentRequest(action.StudentId, action.Name, action.CountryId.ToString(), action.ClassId.ToString(),action.DayofBirth);
        await _addStudentUseCase.Execute(request,_updateStudentPresenter);

        var responseJsonString = _updateStudentPresenter.GetJsonString();
        var updateStudentClientResponse = JsonSerializer.Deserialize<UpdateStudentClientResponse>(responseJsonString);

        if (updateStudentClientResponse is not null)
        {
            dispatcher.Dispatch(new UpdateStudentResultAction());
        }
    }
}