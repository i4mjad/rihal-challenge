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
            ClassName = GetClassName(studentDataModel.ClassId),
            CountryName = GetCountryName(studentDataModel.CountryId)
        };
    }
    
    public Task AddStudent(Student student, Guid classId, Guid countryId)
    {
        var studentDataModel = new StudentDataModel()
        {
            Id = student.Id,
            Name = student.StudentName,
            CountryId = countryId,
            ClassId = classId,
            DayOfBirth = new DateTime(1998,08,28)
        };
         _inMemoryDataSource.StudentsDataSet().Add(studentDataModel);
        var cake = _inMemoryDataSource.StudentsDataSet().GetAll();
        return Task.CompletedTask;
    }

    public Task UpdateStudent(Guid id, string newName, Guid newClassId, Guid newCountryId, DateTime newDayOfBirth)
    {
        var studentDataModels = _inMemoryDataSource.StudentsDataSet().GetAll();
        var currentStudent = studentDataModels.FirstOrDefault(x=>x.Id == id);

        var updatedStudent = new StudentDataModel()
        {
            Id = id,
            CountryId = newCountryId,
            Name = newName,
            ClassId = newClassId,
            DayOfBirth = newDayOfBirth
        }; 
        _inMemoryDataSource.StudentsDataSet().Update(currentStudent!,updatedStudent);

        return Task.CompletedTask;
    }

    public Task<Student> GetStudent(Guid id)
    {
        var studentsDataModels = _inMemoryDataSource.StudentsDataSet().GetAll();
        var studentDataModel = studentsDataModels.First(student => student.Id == id);
        var student = new Student()
        {
            Id = studentDataModel.Id,
            StudentName = studentDataModel.Name,
            ClassName = GetClassName(studentDataModel.ClassId),
            CountryName = GetCountryName(studentDataModel.CountryId)
        };
        return Task.FromResult(student);
    }

    private string GetClassName(Guid classId)
    {
        var classesDataModels = _inMemoryDataSource.ClassDataSet().GetAll();
        var classDataModel = classesDataModels.First(x => x.Id == classId);
        return classDataModel.Name;
    }

    private string GetCountryName(Guid countryId)
    {
        var countriesDataModels = _inMemoryDataSource.CountryDataSet().GetAll();
        var countryDataModel = countriesDataModels.First(x => x.Id == countryId);
        return countryDataModel.Name;
    }
}