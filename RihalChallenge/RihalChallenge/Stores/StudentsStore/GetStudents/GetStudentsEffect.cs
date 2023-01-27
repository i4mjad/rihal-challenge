using System.Text.Json;
using Fluxor;
using RihalChallenge.Client.Models;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Client.Stores.StudentsStore;
using RihalChallenge.Domain.UseCases;
using RihalChallenge.Domain.UseCases.Students.DeleteStudentUseCase;
using RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;

namespace RihalChallenge.Client.Stores;

public class GetStudentsEffect: Effect<GetStudentsAction>
{
    private readonly IGetStudentsUseCase _getStudentsUseCase;
    private readonly IBlazorPresenter<GetStudentsResponse> _getStudentsPresenter;

    public GetStudentsEffect(IGetStudentsUseCase getStudentsUseCase, IBlazorPresenter<GetStudentsResponse> getStudentsPresenter, IDeleteStudentUseCase deleteStudentUseCase)
    {
        _getStudentsUseCase = getStudentsUseCase;
        _getStudentsPresenter = getStudentsPresenter;
    }

    public override async Task HandleAsync(GetStudentsAction action, IDispatcher dispatcher)
    {
        await _getStudentsUseCase.Execute(_getStudentsPresenter);

        var responseJsonString = _getStudentsPresenter.GetJsonString();
        var getStudentsClientResponse = JsonSerializer.Deserialize<GetStudentsClientResponse>(responseJsonString);

        if (getStudentsClientResponse != null)
        {
            dispatcher.Dispatch(new GetStudentsResultAction(getStudentsClientResponse!.Students));
        }
    }
}