using System.Text.Json;
using Fluxor;
using RihalChallenge.Client.Models;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Client.Stores.StudentsStore;
using RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;

namespace RihalChallenge.Client.Stores;

public class Effects
{
    private readonly IGetStudentsUseCase _getStudentsUseCase;
    private readonly IGetStudentBlazorPresenter _presenter;

    public Effects(IGetStudentsUseCase getStudentsUseCase, IGetStudentBlazorPresenter presenter)
    {
        _getStudentsUseCase = getStudentsUseCase;
        _presenter = presenter;
    }

    [EffectMethod(typeof(GetStudentsAction))]
    public async Task HandleFetchDataAction(IDispatcher dispatcher)
    {
        await _getStudentsUseCase.Execute(_presenter);
        
        var responseJsonString = _presenter.GetJsonString();
        var getStudentsClientResponse = JsonSerializer.Deserialize<GetStudentsClientResponse>(responseJsonString);
        
        dispatcher.Dispatch(new GetStudentsResultAction(getStudentsClientResponse!.Students));
        
    }
}