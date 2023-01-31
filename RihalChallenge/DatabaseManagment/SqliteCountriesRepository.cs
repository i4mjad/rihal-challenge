using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;
using RihalChallenge.Domain.Entities;
using RihalChallenge.Domain.Repositories;

namespace DatabaseManagment;

public class SqliteCountriesRepository: ICountriesRepository
{
    private IDbConnection GetConnection()
    {
        return new SqliteConnection(@"Data Source=./RihalChallengeDB.db;Version=3;New=true;");
    }

    public async Task<IEnumerable<Country>> GetAllCountries()
    {
        using var cnn = GetConnection();
        cnn.Open();
        var classes = await cnn.QueryAsync<Country>(
            "SELECT * from Countries"
        );
        return classes;
    }

    public async Task<Country> GetById(string countryId)
    {
        using var cnn = GetConnection();
        cnn.Open();
        var sqlQuery = "SELECT * FROM Countries Where Id = @Id";
        var queryAsync = await cnn.QueryAsync<Country>(sqlQuery, new { Id = countryId });
        return queryAsync.First();
    }

    public async Task AddCountry(Country newCountry)
    {
        var countryDataModel = new
        {
            Id=newCountry,
            nameof = newCountry
        };

        using (var cnn = GetConnection())
        {
            cnn.Open();
            var sqlQuery = $"INSERT INTO Countries (Id, Name) VALUES(@Id, @Name)";
            await cnn.ExecuteAsync(sqlQuery, countryDataModel);
        }
    }

    public async Task DeleteCountry(Guid countryId)
    {
        using (var cnn = GetConnection())
        {
            cnn.Open();
            var sqlQuery = "Delete from Countries Where Id = @Id";
            await cnn.ExecuteAsync(sqlQuery, new { Id = countryId.ToString() });
        }
    }

    public async Task UpdateCountry(Guid id, string newName)
    {
        var countryDataModel = new 
        {
            Id = id.ToString(),
            Name = newName,
        };

        using (var cnn = GetConnection())
        {
            cnn.Open();
            var sqlQuery = $"Update Countries (Id, Name) VALUES(@Id, @Name)";
            await cnn.ExecuteAsync(sqlQuery, countryDataModel);
        }
    }
}