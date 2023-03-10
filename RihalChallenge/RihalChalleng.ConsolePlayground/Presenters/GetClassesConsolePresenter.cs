using RihalChallenge.Domain.UseCases.Classes.GetClassesUseCase;

namespace RihalChallenge.ConsolePlayground.Presenters;

public class GetClassesConsolePresenter: IGetClassesPresenter
{
    public void Success(GetClassesResponse response)
    {
        var allClasses = response.Classes;
        //TODO: consider renaming Class entity to another name to avoid conflict with 'Class' keyword 
        foreach (var singleClasses in allClasses)
        {
            Console.WriteLine($"Id: {singleClasses.Id}, Class: {singleClasses.Name}");
        }
    }

    public void Error(string error)
    {
        throw new NotImplementedException();
    }
}