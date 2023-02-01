using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;
using RihalChallenge.Domain.DataModels;
using RihalChallenge.Domain.Entities;
using RihalChallenge.Domain.Repositories;

namespace DatabaseManagment;

public class SqliteCountriesRepository: ICountriesRepository
{
    private IDbConnection GetConnection()
    {
        return new SqliteConnection(@"Data Source=AppDB.db");
    }

    public async Task<IEnumerable<Country>> GetAllCountries()
    {
        using var cnn = GetConnection();
        cnn.Open();
        var classes = await cnn.QueryAsync<CountryDataModel>(
            "SELECT * from Countries"
        );
        return classes.Select(x=> new Country()
        {
            Id = Guid.Parse(x.Id),
            CountryName = x.CountryName
        });
    }

    public async Task<Country> GetById(string countryId)
    {
        using var cnn = GetConnection();
        cnn.Open();
        var sqlQuery = "SELECT * FROM Countries Where Id = @Id";
        var datamodels = await cnn.QueryAsync<CountryDataModel>(sqlQuery, new { Id = countryId });
        var domainModels = datamodels.Select(x => new Country()
        {
            Id = Guid.Parse(x.Id),
            CountryName = x.CountryName
        });
        return domainModels.First();
    }

    public async Task AddCountry(Country newCountry)
    {
        var countryDataModel = new CountryDataModel()
        {
            Id = newCountry.Id.ToString(),
            CountryName = newCountry.CountryName
        };

        using (var cnn = GetConnection())
        {
            cnn.Open();
            var sqlQuery = $"INSERT INTO Countries (Id, CountryName) VALUES(@Id, @CountryName)";
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
            CountryName = newName,
        };

        using (var cnn = GetConnection())
        {
            cnn.Open();
            var sqlQuery = "UPDATE Countries SET CountryName = @CountryName WHERE Id = @Id";
            await cnn.ExecuteAsync(sqlQuery, countryDataModel);
        }
    }
}