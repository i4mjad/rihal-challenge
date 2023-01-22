using RihalChallenge.Domain.UseCases.Students.DeleteStudentUseCase;
using RihalChallenge.Domain.UseCases.Students.UpdateStudentUseCase;

namespace RihalChallenge.ConsolePlayground.Presenters;

class DeleteStudentConsolePresenter : IDeleteStudentPresenter
{
    public void Success(string message)
    {
        Console.WriteLine($"A user has been delete");
    }

    public void Error(string error)
    {
        throw new NotImplementedException();
    }
}