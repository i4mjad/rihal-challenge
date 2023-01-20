using RihalChallenge.Domain.UseCases.GetStudentsUseCase;

namespace RihalChallenge.ConsolePlayground;
public class GetStudentsConsolePresenter: IGetStudentsPresenter
{
    public void Success(GetStudentsResponse response)
    {
        var students = response.Students;
        foreach (var student in students)
        {
            Console.WriteLine($"Name: {student.StudentName}, Class: {student.ClassName}, Country: {student.CountryName}, Date of birth: {student.DayOfBirth}");
        }
    }

    public void Error(string error)
    {
        throw new NotImplementedException();
    }
}

