using System.Text.Json;
using Fluxor;
using RihalChallenge.Client.Models.Classes;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Domain.UseCases.Classes.GetStudentUseCase;

namespace RihalChallenge.Client.Store.Classes.GetClass;

public class GetClassEffect: Effect<GetClassAction>
{
    private readonly IGetClassUseCase _getClassUseCase;
    private readonly IBlazorPresenter<GetClassResponse> _presenter;

    public GetClassEffect(IGetClassUseCase getClassUseCase, IBlazorPresenter<GetClassResponse> presenter)
    {
        _getClassUseCase = getClassUseCase;
        _presenter = presenter;
    }

    public override async Task HandleAsync(GetClassAction action, IDispatcher dispatcher)
    {
        var request = new GetClassRequest(action.ClassId);
        await _getClassUseCase.Execute(request,_presenter);

        var responseJsonString = _presenter.GetJsonString();
        var getClassClientResponse = JsonSerializer.Deserialize<GetClassClientResponse>(responseJsonString);

        if (getClassClientResponse != null)
        {
            dispatcher.Dispatch(new GetClassResultAction(getClassClientResponse!.Class));
        }
    }
}