using System.Text.Json;
using Fluxor;
using RihalChallenge.Client.Models.Students;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Domain.UseCases.Students.GetStudentUseCase;

namespace RihalChallenge.Client.Store.Students.GetStudent;

public class GetStudentEffect: Effect<GetStudentAction>
{
    private readonly IGetStudentUseCase _getStudentUseCase;
    private readonly IBlazorPresenter<GetStudentResponse> _presenter;

    public GetStudentEffect(IGetStudentUseCase getStudentUseCase, IBlazorPresenter<GetStudentResponse> presenter)
    {
        _getStudentUseCase = getStudentUseCase;
        _presenter = presenter;
    }

    public override async Task HandleAsync(GetStudentAction action, IDispatcher dispatcher)
    {
        var request = new GetStudentRequest(action.StudentId);
        await _getStudentUseCase.Execute(request,_presenter);

        var responseJsonString = _presenter.GetJsonString();
        var getStudentClientResponse = JsonSerializer.Deserialize<GetStudentClientResponse>(responseJsonString);

        if (getStudentClientResponse != null)
        {
            dispatcher.Dispatch(new GetStudentResultAction(getStudentClientResponse!.Student));
        }
    }
}