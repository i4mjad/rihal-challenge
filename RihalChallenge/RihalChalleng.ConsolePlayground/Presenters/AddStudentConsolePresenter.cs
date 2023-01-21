using RihalChallenge.Domain.UseCases.Students.AddStudentUseCase;
using RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;

namespace RihalChallenge.ConsolePlayground.Presenters;

public class AddStudentConsolePresenter: IAddStudentPresenter
{
    public void Success(AddStudentResponse response)
    {
        Console.WriteLine($"The new user has been added with Id {response.Id}");
    }

    public void Error(string error)
    {
        throw new NotImplementedException();
    }
}