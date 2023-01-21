using RihalChallenge.Domain.DataModels;
using RihalChallenge.Domain.DataSources;
using RihalChallenge.Domain.Entites;
using RihalChallenge.Domain.Entities;

namespace RihalChallenge.Domain.Repositories.InMemory;

public class InMemoryStudentsRepository: IStudentsRepository
{
    private readonly IInMemoryDataSource _inMemoryDataSource;

    public InMemoryStudentsRepository(IInMemoryDataSource inMemoryDataSource)
    {
        _inMemoryDataSource = inMemoryDataSource;
    }
    public Task<IEnumerable<Student>> GetAllStudents()
    {
        var allStudentsDataModel = _inMemoryDataSource.StudentsDataSet().GetAll();
        var allStudents = allStudentsDataModel.Select(GetStudentFromDataModel);
        return Task.FromResult(allStudents);
    }

    private Student GetStudentFromDataModel(StudentDataModel studentDataModel)
    {
        return new Student()
        {
            Id = studentDataModel.Id,
            DayOfBirth = studentDataModel.DayOfBirth,
            StudentName = studentDataModel.Name,
            Class = GetClass(studentDataModel.ClassId),
            Country = GetCountry(studentDataModel.CountryId)
        };
    }
    
    public Task AddStudent(Student student)
    {
        var studentDataModel = new StudentDataModel()
        {
            Id = student.Id,
            Name = student.StudentName,
            CountryId = student.Country.Id,
            ClassId = student.Class.Id,
            DayOfBirth = new DateTime(1998,08,28)
        };
         _inMemoryDataSource.StudentsDataSet().Add(studentDataModel);
        var cake = _inMemoryDataSource.StudentsDataSet().GetAll();
        return Task.CompletedTask;
    }

    private Class GetClass(Guid classId)
    {
        var classesDataModels = _inMemoryDataSource.ClassDataSet().GetAll();
        var classDataModel = classesDataModels.First(x => x.Id == classId);
        return new Class()
        {
            Id = classDataModel.Id,
            Name = classDataModel.Name
        };
    }

    private Country GetCountry(Guid countryId)
    {
        var countriesDataModels = _inMemoryDataSource.CountryDataSet().GetAll();
        var countryDataModel = countriesDataModels.First(x => x.Id == countryId);
        return new Country()
        {
            Id = countryDataModel.Id,
            Name = countryDataModel.Name
        };
    }
}