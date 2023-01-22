using RihalChallenge.Domain.DataModels;
using RihalChallenge.Domain.DataSources;
using RihalChallenge.Domain.Entites;

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
        var allStudentsDataModel = _inMemoryDataSource.ClassDataSet().GetAll();

        return Task.FromResult(allStudentsDataModel.Select(GetClassesFromDataModel));
    }

    public Task<Class> GetById(string classId)
    {
        var classesDataModels = _inMemoryDataSource.ClassDataSet().GetAll();
        var classDataModel = classesDataModels.First(x => x.Id == Guid.Parse(classId));
        var model = new Class()
        {
            Id = classDataModel.Id,
            Name = classDataModel.Name
        };
        return Task.FromResult(model);
    }

    private Class GetClassesFromDataModel(ClassDataModel classDataModel)
    {
        return new Class()
        {
            Id = classDataModel.Id,
            Name = classDataModel.Name
        };
    }
}