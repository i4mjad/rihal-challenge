using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
namespace RihalChallenge.Client.Presenters;

public class BlazorPresenter<T>: IBlazorPresenter<T>
{
    private T domainResponse { get; set; }
    public void Success(T response)
    {
        domainResponse = response;
    }

    public void Error(string error)
    {
        throw new NotImplementedException();
    }

    public ActionResult GetJsonResponse()
    {
        return new OkObjectResult(domainResponse);
    }

    public string GetJsonString()
    {
        string jsonString = JsonSerializer.Serialize(domainResponse);
        return jsonString;
    }
}