using RihalChallenge.Domain.Entities;
using RihalChallenge.Domain.Repositories;

namespace RihalChallenge.Domain.UseCases.Statistics.GetClassesStatistics;

public class GetClassesStatisticsUseCase:IGetClassesStatisticsUseCase
{
    private readonly IClassesRepository _classesRepository;
    private readonly IStudentsRepository _studentsRepository;

    public GetClassesStatisticsUseCase(IClassesRepository classesRepository, IStudentsRepository studentsRepository)
    {
        _classesRepository = classesRepository;
        _studentsRepository = studentsRepository;
    }
    public async Task Execute(IPresenter<GetClassesStatisticsResponse> presenter)
    {
        var classes = await _classesRepository.GetAllClasses();
        var students = await _studentsRepository.GetAllStudents();
        var statisticsList = new List<ClassStatistics>(){};
        foreach (var studentsClass in classes)
        {
            var studentsWithClass = students.Where(student => student.ClassName == studentsClass.Name).ToList();
            var classStatistics = new ClassStatistics(studentsClass.Name, studentsWithClass.Count.ToString());
            statisticsList.Add(classStatistics);
        }
        presenter.Success(new GetClassesStatisticsResponse(statisticsList));
    }
}