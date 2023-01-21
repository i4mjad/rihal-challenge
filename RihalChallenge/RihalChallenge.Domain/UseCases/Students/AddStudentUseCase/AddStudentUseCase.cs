using RihalChallenge.Domain.DataModels;
using RihalChallenge.Domain.Entites;
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
    public async Task Execute(AddStudentRequest request, IAddStudentPresenter addStudentPresenter)
    {
        var studentClass = await _classesRepository.GetByName(request.className);
        var studentCountry = await _countriesRepository.GetByName(request.countryName);

        var student = new Student()
        {
            Id = Guid.NewGuid(),
            StudentName = request.name,
            Class = studentClass,
            Country = studentCountry
        };
        await _studentsRepository.AddStudent(student);
        var cake = await _studentsRepository.GetAllStudents();
        addStudentPresenter.Success(new AddStudentResponse(student.Id));
    }

    
}