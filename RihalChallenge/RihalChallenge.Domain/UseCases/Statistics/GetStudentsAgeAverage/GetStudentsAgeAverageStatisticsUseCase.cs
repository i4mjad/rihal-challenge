using RihalChallenge.Domain.Entities;
using RihalChallenge.Domain.Repositories;

namespace RihalChallenge.Domain.UseCases.Statistics.GetStudentsAgeAverage;

public class GetStudentsAgeAverageUseCase:IGetStudentsAgeAverageUseCase
{
    private readonly IStudentsRepository _studentsRepository;

    public GetStudentsAgeAverageUseCase(IStudentsRepository studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }
    public async Task Execute(IPresenter<GetStudentsAgeAverageResponse> presenter)
    {
        var students = await _studentsRepository.GetAllStudents();
        var studentsList = students.ToList();
        var studentsAgeAverage = studentsList.Select(student => student.Age).Sum() / studentsList.ToList().Count;
        
        presenter.Success(new GetStudentsAgeAverageResponse(studentsAgeAverage));
    }
}