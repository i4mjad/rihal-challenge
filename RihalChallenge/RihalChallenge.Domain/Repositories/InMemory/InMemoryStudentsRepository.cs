using RihalChallenge.Domain.DataModels;
using RihalChallenge.Domain.DataSources;
using RihalChallenge.Domain.Entities;
using RihalChallenge.Domain.UseCases.GetStudentsUseCase;

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

        return Task.FromResult(allStudentsDataModel.Select(GetStudentFromDataModel));
    }

    private Student GetStudentFromDataModel(StudentDataModel studentDataModel)
    {
        return new Student()
        {
            Id = studentDataModel.Id,
            DayOfBirth = studentDataModel.DayOfBirth,
            StudentName = studentDataModel.Name,
            ClassName = GetClassName(studentDataModel.ClassId),
            CountryName = GetCountryName(studentDataModel.CountryId)
        };
    }

    private string GetClassName(Guid classId)
    {
        var classesDataModels = _inMemoryDataSource.ClassDataSet().GetAll();
        var classDataModel = classesDataModels.First(x => x.Id == classId);
        return classDataModel.Name;
    }

    private string GetCountryName(Guid classId)
    {
        var countriesDataModels = _inMemoryDataSource.CountryDataSet().GetAll();
        var countryDataModel = countriesDataModels.First(x => x.Id == classId);
        return countryDataModel.Name;
    }
}