using Microsoft.AspNetCore.Mvc;
using RihalChallenge.Domain.UseCases;
using RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;

namespace RihalChallenge.Client.Presenters;

public interface IBlazorPresenter<T> : IPresenter<T>
{
    public ActionResult GetJsonResponse();
    public string GetJsonString();
}