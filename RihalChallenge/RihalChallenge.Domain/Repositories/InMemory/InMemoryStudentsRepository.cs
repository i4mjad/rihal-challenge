using RihalChallenge.Domain.DataModels;
using RihalChallenge.Domain.DataSources;
using RihalChallenge.Domain.Entities;

namespace RihalChallenge.Domain.Repositories.InMemory;

//TODO: multipule repository does not use the created method to map from the data model to the domain model, consider
//      using it to make the code more cleaner
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
            Id = Guid.Parse(studentDataModel.Id),
            DayOfBirth = DateTime.Parse(studentDataModel.DayOfBirth),
            StudentName = studentDataModel.Name,
            ClassName = GetClassName(Guid.Parse(studentDataModel.ClassId)),
            CountryName = GetCountryName(Guid.Parse(studentDataModel.CountryId))
        };
    }
    
    public Task AddStudent(Student student, Guid classId, Guid countryId)
    {
        var studentDataModel = new StudentDataModel()
        {
            Id = student.Id.ToString(),
            Name = student.StudentName,
            CountryId = countryId.ToString(),
            ClassId = classId.ToString(),
            DayOfBirth = student.DayOfBirth.ToString()
        };
         _inMemoryDataSource.StudentsDataSet().Add(studentDataModel);
         return Task.CompletedTask;
    }



    public Task UpdateStudent(Guid id, string newName, Guid newClassId, Guid newCountryId, DateTime newDayOfBirth)
    {
        var studentDataModels = _inMemoryDataSource.StudentsDataSet().GetAll();
        var currentStudent = studentDataModels.FirstOrDefault(x=>x.Id == id.ToString());

        var updatedStudent = new StudentDataModel()
        {
            Id = id.ToString(),
            CountryId = newCountryId.ToString(),
            Name = newName,
            ClassId = newClassId.ToString(),
            DayOfBirth = newDayOfBirth.ToString()
        }; 
        _inMemoryDataSource.StudentsDataSet().Update(currentStudent!,updatedStudent);

        return Task.CompletedTask;
    }

    public Task<Student> GetStudent(Guid id)
    {
        var studentsDataModels = _inMemoryDataSource.StudentsDataSet().GetAll();
        var studentDataModel = studentsDataModels.First(student => student.Id == id.ToString());
        var student = new Student()
        {
            Id = Guid.Parse(studentDataModel.Id),
            StudentName = studentDataModel.Name,
            ClassName = GetClassName(Guid.Parse(studentDataModel.ClassId)),
            CountryName = GetCountryName(Guid.Parse(studentDataModel.CountryId))
        };
        return Task.FromResult(student);
    }

    public Task DeleteStudent(Guid id)
    {
        var studentsDataModels = _inMemoryDataSource.StudentsDataSet().GetAll();
        var studentDataModel = studentsDataModels.First(student => Guid.Parse(student.Id) == id);
        
        _inMemoryDataSource.StudentsDataSet().Delete(studentDataModel);
        return Task.CompletedTask;
    }

    private string GetClassName(Guid classId)
    {
        var classesDataModels = _inMemoryDataSource.ClassDataSet().GetAll();
        var classDataModel = classesDataModels.First(x => Guid.Parse(x.Id) == classId);
        return classDataModel.ClassName;
    }

    private string GetCountryName(Guid countryId)
    {
        var countriesDataModels = _inMemoryDataSource.CountryDataSet().GetAll();
        var countryDataModel = countriesDataModels.First(x => Guid.Parse(x.Id) == countryId);
        return countryDataModel.CountryName;
    }
}