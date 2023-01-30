using Fluxor;

namespace RihalChallenge.Client.Store.Statstics.GetClass;

public class GetClassesStatisticsEffect: Effect<GetClassesStatisticsAction>
{
    
    //TODO: Inject the use case and presenter interface
    // private readonly IGetClassUseCase _getClassUseCase;
    // private readonly IBlazorPresenter<GetClassResponse> _presenter;

    public GetClassesStatisticsEffect()
    {
        
    }

    public override async Task HandleAsync(GetClassesStatisticsAction action, IDispatcher dispatcher)
    {
        //TODO: execute the use case and present the response 
        // var request = new GetClassRequest(action.ClassId);
        // await _getClassUseCase.Execute(request,_presenter);
        //
        // var responseJsonString = _presenter.GetJsonString();
        // var getClassClientResponse = JsonSerializer.Deserialize<GetClassClientResponse>(responseJsonString);
        //
        // if (getClassClientResponse != null)
        // {
        //     dispatcher.Dispatch(new GetClassesStatisticsAction(getClassClientResponse!.Class));
        // }
    }
}