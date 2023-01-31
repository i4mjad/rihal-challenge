using RihalChallenge.Domain.DataModels;
using RihalChallenge.Domain.DataSources;
using RihalChallenge.Domain.Entities;

namespace RihalChallenge.Domain.Repositories.InMemory;

public class InMemoryClassesRepository: IClassesRepository
{
    private readonly IInMemoryDataSource _inMemoryDataSource;

    public InMemoryClassesRepository(IInMemoryDataSource inMemoryDataSource)
    {
        _inMemoryDataSource = inMemoryDataSource;
    }
    public Task<IEnumerable<Class>> GetAllClasses()
    {
        var allClassesDataModels = _inMemoryDataSource.ClassDataSet().GetAll();

        return Task.FromResult(allClassesDataModels.Select(GetClassesFromDataModel));
    }

    public Task<Class> GetById(string classId)
    {
        var classesDataModels = _inMemoryDataSource.ClassDataSet().GetAll();
        var classDataModel = classesDataModels.First(x => Guid.Parse(x.Id) == Guid.Parse(classId));
        var model = new Class()
        {
            Id = Guid.Parse(classDataModel.Id),
            Name = classDataModel.Name
        };
        return Task.FromResult(model);
    }

    public Task AddClass(Class newClass)
    {
        _inMemoryDataSource.ClassDataSet().Add(new ClassDataModel()
        {
            Id = newClass.Id.ToString(),
            Name = newClass.Name
        });

        return Task.CompletedTask;
    }

    public Task DeleteClass(Guid classId)
    {
        var getAllClasses = _inMemoryDataSource.ClassDataSet().GetAll();
        var classDataModel = getAllClasses.First(x => Guid.Parse(x.Id) == classId);
        _inMemoryDataSource.ClassDataSet().Delete(classDataModel);
        
        return Task.CompletedTask;
    }

    public Task UpdateClass(Guid id, string newName)
    {
        var classesDataModels = _inMemoryDataSource.ClassDataSet().GetAll();
        var currentClass = classesDataModels.FirstOrDefault(x => Guid.Parse(x.Id) == id);
        var updatedClass = new ClassDataModel()
        {
            Id = id.ToString(),
            Name = newName,
        };

        _inMemoryDataSource.ClassDataSet().Update(currentClass!,updatedClass);
        
        return Task.CompletedTask;
    }

    private Class GetClassesFromDataModel(ClassDataModel classDataModel)
    {
        return new Class()
        {
            Id = Guid.Parse(classDataModel.Id),
            Name = classDataModel.Name
        };
    }
}