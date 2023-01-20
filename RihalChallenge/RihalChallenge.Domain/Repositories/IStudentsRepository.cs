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
}