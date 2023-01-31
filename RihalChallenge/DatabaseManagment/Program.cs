// See https://aka.ms/new-console-template for more information
using System;
using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        using (IDbConnection connection = GetConnection())
        {
            connection.Execute("Create Table Students(ID Text, ClassId text, CountryId text, Name varchar, DateOfBirth date)");
        }
    }

    private static IDbConnection GetConnection()
    {
        return new SqliteConnection(@"Data Source=./RihalChallengeDB.db;Version=3;New=true;");
    }
}



