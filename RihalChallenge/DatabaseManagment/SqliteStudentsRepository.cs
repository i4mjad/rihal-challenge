
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
            return new SqliteConnection(@"Data Source=AppDB.db");
        }
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            using var cnn = GetConnection();
            cnn.Open();
            
            var query = "SELECT * " +
                                "" +
                                "FROM Students t1 " +
                                "JOIN Classes t2 ON t2.Id = t1.ClassId " +
                                "JOIN Countries t3 ON t3.Id = t1.CountryId";
            
            
            var students = await cnn.QueryAsync<StudentDataModel>(query);
            return students.Select(student=>new Student()
            {
                Id = Guid.Parse(student.Id),
                ClassName = student.ClassName,
                CountryName = student.CountryName,
                StudentName = student.Name,
                DayOfBirth = DateTime.Parse(student.DayOfBirth),
            });
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
                var sqlQuery = "INSERT INTO Students (Id, ClassId, CountryId, Name, DayOfBirth) VALUES(@Id, @ClassId, @CountryId, @Name, @DayOfBirth)";        
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
                var sqlQuery = "Update Students " +
                               "SET CountryId = @CountryId, " +
                               "Name = @Name, " +
                               "DayOfBirth = @DayOfBirth, " +
                               "ClassID = @ClassId, " +
                               "WHERE Id = @Id";
                    
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
                var sqlQuery = "DELETE from Students Where Id = @Id";
                await cnn.ExecuteAsync(sqlQuery, new {Id = id.ToString()});
            }
        }
    }
}
