using System.Text.Json;
using Fluxor;
using RihalChallenge.Client.Models.Statistics;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Domain.UseCases.Statistics.GetCountriesStatistics;

namespace RihalChallenge.Client.Store.Statistics.GetCountriesStatistics;

public class GetCountriesStatisticsEffect: Effect<GetCountriesStatisticsAction>
{
    
    //TODO: Inject the use case and presenter interface
    private readonly IGetCountriesStatisticsUseCase _getClassUseCase;
    private readonly IBlazorPresenter<GetCountriesStatisticsResponse> _presenter;

    public GetCountriesStatisticsEffect(IGetCountriesStatisticsUseCase getClassUseCase, IBlazorPresenter<GetCountriesStatisticsResponse> presenter)
    {
        _getClassUseCase = getClassUseCase;
        _presenter = presenter;
    }

    public override async Task HandleAsync(GetCountriesStatisticsAction action, IDispatcher dispatcher)
    {
        //TODO: execute the use case and present the response 
        await _getClassUseCase.Execute(_presenter);
        
        var responseJsonString = _presenter.GetJsonString();
        var getClassClientResponse = JsonSerializer.Deserialize<GetCountriesStatisticsClientResponse>(responseJsonString);
        
        if (getClassClientResponse != null)
        {
            dispatcher.Dispatch(new GetCountriesStatisticsResultAction(getClassClientResponse!.CountriesStatistics));
        }
    }
}