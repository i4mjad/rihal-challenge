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

    private Class GetClassesFromDataModel(ClassDataModel classDataModel)
    {
        return new Class()
        {
            Id = classDataModel.Id,
            Name = classDataModel.Name
        };
    }
}