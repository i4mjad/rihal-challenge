using System.Data;
using System.Security.Cryptography.X509Certificates;
using Dapper;
using Microsoft.Data.Sqlite;
using RihalChallenge.Domain.DataModels;
using RihalChallenge.Domain.Entities;
using RihalChallenge.Domain.Repositories;

namespace DatabaseManagment;

public class SqliteClassesRepository: IClassesRepository
{
    private IDbConnection GetConnection()
    {
        var dbPath = Path.Combine(Environment.CurrentDirectory, "RihalChallengeDB.db");
        var connectionString = string.Format("Data Source={0};", dbPath);
        return new SqliteConnection(connectionString);
    }

    public async Task<IEnumerable<Class>> GetAllClasses()
    {
        
        using var cnn = GetConnection();
        // SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
        cnn.Open();
        var classes = await cnn.QueryAsync<ClassDataModel>(
            "SELECT * from Classes"
        );
        return classes.Select(x=>new Class()
        {
            Id = Guid.Parse(x.Id),
            Name = x.Name
        });
    }

    public async Task<Class> GetById(string classId)
    {
        using var cnn = GetConnection();
        cnn.Open();
        var sqlQuery = "SELECT * FROM Classes Where Id = @Id";
        var queryAsync = await cnn.QueryAsync<Class>(sqlQuery, new { Id = classId });
        return queryAsync.First();
    }

    public async Task AddClass(Class newClass)
    {
        var classDataModel = new
        {
            Id=newClass,
            nameof = newClass
        };

        using (var cnn = GetConnection())
        {
            cnn.Open();
            var sqlQuery = $"INSERT INTO Classes (Id, Name) VALUES(@Id, @Name)";
            await cnn.ExecuteAsync(sqlQuery, classDataModel);
                 }
    }

    public async Task DeleteClass(Guid classId)
    {
        using (var cnn = GetConnection())
        {
            cnn.Open();
            var sqlQuery = "Delete from Classes Where Id = @Id";
            await cnn.ExecuteAsync(sqlQuery, new { Id = classId.ToString() });
        }
    }

    public async Task UpdateClass(Guid id, string newName)
    {
        var classDataModel = new 
        {
            Id = id.ToString(),
            Name = newName,
        };

        using (var cnn = GetConnection())
        {
            cnn.Open();
            var sqlQuery = $"Update Classes (Id, Name) VALUES(@Id, @Name)";
            await cnn.ExecuteAsync(sqlQuery, classDataModel);
        }
    }
}