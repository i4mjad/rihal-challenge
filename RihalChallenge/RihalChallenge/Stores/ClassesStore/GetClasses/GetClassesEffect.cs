using System.Text.Json;
using Fluxor;
using RihalChallenge.Client.Models;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Client.Stores.ClassesStore;
using RihalChallenge.Domain.UseCases;
using RihalChallenge.Domain.UseCases.Classes.GetClassesUseCase;
using RihalChallenge.Domain.UseCases.Students.DeleteStudentUseCase;
using RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;

namespace RihalChallenge.Client.Stores.ClassesStore.GetClasses;

public class GetClassesEffect: Effect<GetClassesAction>
{
    private readonly IGetClassesUseCase _getClassesUseCase;
    private readonly IBlazorPresenter<GetClassesResponse> _getClassesPresenter;

    public GetClassesEffect(IGetClassesUseCase getClassesUseCase, IBlazorPresenter<GetClassesResponse> getClassesPresenter, IDeleteStudentUseCase deleteStudentUseCase)
    {
        _getClassesUseCase = getClassesUseCase;
        _getClassesPresenter = getClassesPresenter;
    }

    public override async Task HandleAsync(GetClassesAction action, IDispatcher dispatcher)
    {
        await _getClassesUseCase.Execute(_getClassesPresenter);

        var responseJsonString = _getClassesPresenter.GetJsonString();
        var getClassesClientResponse = JsonSerializer.Deserialize<GetClassesClientResponse>(responseJsonString);

        if (getClassesClientResponse != null)
        {
            dispatcher.Dispatch(new GetClassesResultAction(getClassesClientResponse!.Classes));
        }
    }
}