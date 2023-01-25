using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace RihalChallenge.Client.Presenters;

public class GetStudentsGetStudentBlazorPresenter: IGetStudentBlazorPresenter
{
    private GetStudentsResponse domainResponse { get; set; }
    public void Success(GetStudentsResponse response)
    {
        domainResponse = response;
    }

    public void Error(string error)
    {
        throw new NotImplementedException();
    }

    public IActionResult GetJsonResponse()
    {
        return new OkObjectResult(domainResponse);
    }

    public string GetJsonString()
    {
        string jsonString = JsonSerializer.Serialize(domainResponse);
        return jsonString;
    }

    ActionResult IGetStudentBlazorPresenter.GetJsonResponse()
    {
        throw new NotImplementedException();
    }
}