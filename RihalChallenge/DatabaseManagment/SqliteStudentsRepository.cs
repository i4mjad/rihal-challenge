
using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;
using RihalChallenge.Domain.DataModels;
using RihalChallenge.Domain.Entities;
using RihalChallenge.Domain.Repositories;

namespace DatabaseManagment
{
    public class SqliteStudentsRepository: IStudentsRepository
    {
        private IDbConnection GetConnection()
        {
            return new SqliteConnection(@"Data Source=./RihalChallengeDB.db;Version=3;New=true;");
        }
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            using var cnn = GetConnection();
            cnn.Open();
            var students = await cnn.QueryAsync<Student>(
                "SELECT Students.Id AS Id,"+
                "Students.Name AS Name," +
                "Students.length, "+
                "Students.DayOfBirth AS DayOfBirth," +
                "Students.CountryId AS CountryId," +
                "Countries.Name AS CountryName," +
                "Students.ClassId ClassId," +
                "Classes.Name AS ClassName"+
                "FROM Students" +
                "LEFT JOIN Classes ON Students.ClassId = ClassId"+
                "LEFT JOIN Countries ON Students.CountryId = CountryId"
            );
            return students;
        }

        public async Task AddStudent(Student student, Guid classId, Guid countryId)
        {
            var studentDataModel = new StudentDataModel()
            {
                Id= student.Id.ToString(),
                ClassId = classId.ToString(),
                CountryId = countryId.ToString(),
                Name = student.StudentName,
                DayOfBirth = student.DayOfBirth.ToString(),
            };

            using (var cnn = GetConnection())
            {
                cnn.Open();
                var sqlQuery = $"INSERT INTO Students (Id, ClassId, CountryId, Name, DayOfBirth) VALUES(@Id, @ClassId, @CountryId, @Name, @DayOfBirth)";        
                await cnn.ExecuteAsync(sqlQuery, studentDataModel);
            }
        }

        public async Task UpdateStudent(Guid id, string newName, Guid newClassId, Guid newCountryId, DateTime newDayOfBirth)
        {
            var studentDataModel = new StudentDataModel()
            {
                Id = id.ToString(),
                ClassId = newClassId.ToString(),
                CountryId = newCountryId.ToString(),
                Name = newName,
                DayOfBirth = newDayOfBirth.ToString(),
            };

            using (var cnn = GetConnection())
            {
                cnn.Open();
                var sqlQuery = $"Update Students (Id, ClassId, CountryId, Name, DayOfBirth) VALUES(@Id, @ClassId, @CountryId, @Name, @DayOfBirth)";
                await cnn.ExecuteAsync(sqlQuery, studentDataModel);
            }
        }

        public async Task<Student> GetStudent(Guid id)
        {
            using var cnn = GetConnection();
            cnn.Open();
            var sqlQuery = "SELECT * FROM Students Where Id = @Id";
            var queryAsync = await cnn.QueryAsync<Student>(sqlQuery, new {Id = id.ToString()});  
            return queryAsync.First();
        }

        public async Task DeleteStudent(Guid id)
        {
            using (var cnn = GetConnection())
            {
                cnn.Open();
                var sqlQuery = "Delete from Student Where Id = @Id";
                await cnn.ExecuteAsync(sqlQuery, new {Id = id.ToString()});
            }
        }
    }
}
