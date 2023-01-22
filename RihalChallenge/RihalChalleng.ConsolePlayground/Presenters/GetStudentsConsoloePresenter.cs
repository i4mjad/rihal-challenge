using RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;

namespace RihalChallenge.ConsolePlayground.Presenters;
public class GetStudentsConsolePresenter: IGetStudentsPresenter
{
    public void Success(GetStudentsResponse response)
    {
        var students = response.Students.ToList();
        foreach (var student in students)
        {
            Console.WriteLine($"Id: {student.Id} Name: {student.StudentName}, Class: {student.ClassName}, Country: {student.CountryName}, Date of birth: {student.DayOfBirth}");
        }
    }

    public void Error(string error)
    {
        throw new NotImplementedException();
    }
}