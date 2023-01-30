using System.Text.Json;
using Fluxor;
using RihalChallenge.Client.Models.Statistics;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Domain.UseCases.Statistics.GetStudentsAgeAverage;

namespace RihalChallenge.Client.Store.Statistics.GetStudentsAgeAverage;

public class GetStudentsAgeAverageEffect: Effect<GetStudentsAgeAverageAction>
{
    
    //TODO: Inject the use case and presenter interface
    private readonly IGetStudentsAgeAverageUseCase _getStudentsAgeAverageUseCase;
    private readonly IBlazorPresenter<GetStudentsAgeAverageResponse> _presenter;

    public GetStudentsAgeAverageEffect(IGetStudentsAgeAverageUseCase getStudentsAgeAverageUseCase, IBlazorPresenter<GetStudentsAgeAverageResponse> presenter)
    {
        _getStudentsAgeAverageUseCase = getStudentsAgeAverageUseCase;
        _presenter = presenter;
    }

    public override async Task HandleAsync(GetStudentsAgeAverageAction action, IDispatcher dispatcher)
    {
        //TODO: execute the use case and present the response 
        await _getStudentsAgeAverageUseCase.Execute(_presenter);
        
        var responseJsonString = _presenter.GetJsonString();
        var getStudentAgeAverageClientResponse = JsonSerializer.Deserialize<GetStudentsAgeAverageClientResponse>(responseJsonString);
        
        if (getStudentAgeAverageClientResponse != null)
        {
            dispatcher.Dispatch(new GetStudentsAgeAverageResultAction(getStudentAgeAverageClientResponse!.Average));
        }
    }
}