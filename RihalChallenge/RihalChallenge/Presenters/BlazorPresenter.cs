using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;
using System.Text.Json;
using System.Text.Json.Serialization;
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