using Microsoft.AspNetCore.Mvc;
using RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;

namespace RihalChallenge.Client.Presenters;

public interface IGetStudentBlazorPresenter : IGetStudentsPresenter
{
    public ActionResult GetJsonResponse();
    public string GetJsonString();
}