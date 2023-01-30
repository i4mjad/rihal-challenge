using RihalChallenge.Domain.Entities;

namespace RihalChallenge.Domain.Repositories;

public interface IClassesRepository
{
    public Task<IEnumerable<Class>> GetAllClasses();
    Task<Class> GetById(string classId);
    Task AddClass(Class newClass);

    Task DeleteClass(Guid classId);

    Task UpdateClass(Guid id, string newName);
}