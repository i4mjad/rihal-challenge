using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RihalChallenge.Domain.Entities;

namespace RihalChallenge.Domain.Repositories;
public interface IStudentsRepository
{
    public Task<IEnumerable<Student>> GetAllStudents();
    public Task AddStudent(Student student, Guid classId, Guid countryId);

    public Task UpdateStudent(Guid id, string newName, Guid newClassId, Guid newCountryId, DateTime newDayOfBirth);
    public Task<Student> GetStudent(Guid id);
}