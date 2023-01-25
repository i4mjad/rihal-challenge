using System.Text.Json;
using Fluxor;
using RihalChallenge.Client.Models;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Client.Stores.StudentsStore;
using RihalChallenge.Domain.UseCases;
using RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;

namespace RihalChallenge.Client.Stores;

public class Effects
{
    private readonly IUseCase<GetStudentsResponse> _getStudentsUseCase;
    private readonly IBlazorPresenter<GetStudentsResponse> _presenter;

    public Effects(IUseCase<GetStudentsResponse> getStudentsUseCase, IBlazorPresenter<GetStudentsResponse> presenter)
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