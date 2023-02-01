
using RihalChallenge.Domain.Entities;
using RihalChallenge.Domain.Repositories;


namespace RihalChallenge.Domain.UseCases.Students.AddStudentUseCase;

public class AddStudentUseCase : IAddStudentUseCase
{
    private readonly IStudentsRepository _studentsRepository;
    private readonly ICountriesRepository _countriesRepository;
    private readonly IClassesRepository _classesRepository;
    
    public AddStudentUseCase(IStudentsRepository studentsRepository, ICountriesRepository countriesRepository, IClassesRepository classesRepository)
    {
        _studentsRepository = studentsRepository;
        _countriesRepository = countriesRepository;
        _classesRepository = classesRepository;
    }
    public async Task Execute(AddStudentRequest request, IPresenter<AddStudentResponse> presenter)
    {
        var studentClass = await _classesRepository.GetById(request.ClassId);
        var studentCountry = await _countriesRepository.GetById(request.CountryId);

        var student = new Student()
        {
            Id = Guid.NewGuid(),
            StudentName = request.Name,
            ClassName = studentClass.Name,
            CountryName = studentCountry.CountryName,
            DayOfBirth = request.DayOfBirth
            
        };
        await _studentsRepository.AddStudent(student, Guid.Parse(request.ClassId), Guid.Parse(request.CountryId));
        presenter.Success(new AddStudentResponse(student.Id));
    }

    
}