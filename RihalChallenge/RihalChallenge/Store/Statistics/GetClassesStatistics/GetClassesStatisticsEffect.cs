using System.Text.Json;
using Fluxor;
using RihalChallenge.Client.Models.Statistics;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Domain.UseCases.Statistics.GetClassesStatistics;

namespace RihalChallenge.Client.Store.Statistics.GetClassesStatistics;

public class GetClassesStatisticsEffect: Effect<GetClassesStatisticsAction>
{
    
    //TODO: Inject the use case and presenter interface
    private readonly IGetClassesStatisticsUseCase _getClassUseCase;
    private readonly IBlazorPresenter<GetClassesStatisticsResponse> _presenter;

    public GetClassesStatisticsEffect(IGetClassesStatisticsUseCase getClassUseCase, IBlazorPresenter<GetClassesStatisticsResponse> presenter)
    {
        _getClassUseCase = getClassUseCase;
        _presenter = presenter;
    }

    public override async Task HandleAsync(GetClassesStatisticsAction action, IDispatcher dispatcher)
    {
        //TODO: execute the use case and present the response 
        await _getClassUseCase.Execute(_presenter);
        
        var responseJsonString = _presenter.GetJsonString();
        var getClassClientResponse = JsonSerializer.Deserialize<GetClassesStatisticsClientResponse>(responseJsonString);
        
        if (getClassClientResponse != null)
        {
            dispatcher.Dispatch(new GetClassesStatisticsResultAction(getClassClientResponse!.ClassesStatistics));
        }
    }
}