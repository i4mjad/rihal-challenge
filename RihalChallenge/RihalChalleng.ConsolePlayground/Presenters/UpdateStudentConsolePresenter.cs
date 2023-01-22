using RihalChallenge.Domain.UseCases.Students.UpdateStudentUseCase;

namespace RihalChallenge.ConsolePlayground.Presenters;

class UpdateStudentConsolePresenter : IUpdateStudentPresenter
{
    public void Success(UpdateStudentResponse response)
    {
        Console.WriteLine($"A user with Id: {response.UpdatedStudentId} has been updated");
    }

    public void Error(string error)
    {
        throw new NotImplementedException();
    }
}