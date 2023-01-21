using RihalChallenge.Domain.Entites;

namespace RihalChallenge.Domain.Repositories;

public interface IClassesRepository
{
    public Task<IEnumerable<Class>> GetAllClasses();
    Task<Class> GetByName(string requestClassName);
}