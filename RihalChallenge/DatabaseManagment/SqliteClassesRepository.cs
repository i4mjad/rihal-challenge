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
        var dbPath = Path.Combine(Environment.CurrentDirectory, "AppDB.db");
        var connectionString = string.Format("Data Source={0};", dbPath);
        return new SqliteConnection(connectionString);
    }

    public async Task<IEnumerable<Class>> GetAllClasses()
    {
        
        using var cnn = GetConnection();
        cnn.Open();
        var classes = await cnn.QueryAsync<ClassDataModel>(
            "SELECT * from Classes"
        );
        return classes.Select(x=>new Class()
        {
            Id = Guid.Parse(x.Id),
            Name = x.ClassName
        });
    }

    public async Task<Class> GetById(string classId)
    {
        using var cnn = GetConnection();
        cnn.Open();
        var sqlQuery = "SELECT * FROM Classes Where Id = @Id";
        var queryAsync = await cnn.QueryAsync<ClassDataModel>(sqlQuery, new { Id = classId });
        return queryAsync.Select(x=>new Class()
        {
            Id = Guid.Parse(x.Id),
            Name = x.ClassName
        }).First();
    }

    public async Task AddClass(Class newClass)
    {
        var classDataModel = new
        {
            Id=newClass.Id.ToString(),
            ClassName = newClass.Name
        };

        using var cnn = GetConnection();
        cnn.Open();
        var sqlQuery = $"INSERT INTO Classes (Id, ClassName) VALUES(@Id, @ClassName)";
        await cnn.ExecuteAsync(sqlQuery, classDataModel);
    }

    public async Task DeleteClass(Guid classId)
    {
        using var cnn = GetConnection();
        cnn.Open();
        var sqlQuery = "Delete from Classes Where Id = @Id";
        await cnn.ExecuteAsync(sqlQuery, new { Id = classId.ToString() });
    }

    public async Task UpdateClass(Guid id, string newName)
    {
        var classDataModel = new 
        {
            Id = id.ToString(),
            ClassName = newName,
        };

        using var cnn = GetConnection();
        cnn.Open();
        var sqlQuery = $"UPDATE Classes SET ClassName = @Name WHERE Id = @Id";
        await cnn.ExecuteAsync(sqlQuery, classDataModel);
    }
}