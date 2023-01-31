using System.Data;
using Microsoft.Data.Sqlite;
using RihalChallenge.Domain.Entities;
using RihalChallenge.Domain.Repositories;

namespace RihalChallenge.DatabaseManagement
{
    public class SQLiteStudentsRepository: IStudentsRepository, IDisposable
    {

        private IDbConnection GetConnection()
        {
           return new SqliteConnection(@"Data Source=./RihalChallengeDB.db;Version=3;New=true;");
        }
        public Task<IEnumerable<Student>> GetAllStudents()
        {
            
        }

        public Task AddStudent(Student student, Guid classId, Guid countryId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStudent(Guid id, string newName, Guid newClassId, Guid newCountryId, DateTime newDayOfBirth)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudent(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStudent(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}