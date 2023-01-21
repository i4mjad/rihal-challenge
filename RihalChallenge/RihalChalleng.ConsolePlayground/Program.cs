//TODO: This is a playground for testing the application business logic since I still have a small knowledge about Blazor. 

using Microsoft.Extensions.DependencyInjection;
using RihalChallenge.Domain.DataSources;
using RihalChallenge.Domain.Repositories;
using RihalChallenge.Domain.Repositories.InMemory;
using RihalChallenge.Domain.UseCases.Classes.GetClassesUseCase;
using RihalChallenge.Domain.UseCases.Countries.GetCountriesUseCase;
using RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;
using RihalRihalChallenge.Domain.UseCases.Countries.GetCountriesUseCase;
using RihalRihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;

namespace RihalChallenge.ConsolePlayground;

public class Program
{
    public static void Main(string[] args)
    {
        //TODO: consider creating a generic presenter interface instead of creating presenters for each use case
        //DI Container
        var serviceProvider = new ServiceCollection()
            //In-Memory Data set
            .AddScoped<IInMemoryDataSource, InMemoryDataSource>()
            //
            .AddScoped<IStudentsRepository, InMemoryStudentsRepository>()
            .AddScoped<IGetStudentsPresenter, GetStudentsConsolePresenter>()
            .AddScoped<IGetStudentsUseCase, GetStudentsUseCase>()
            //
            .AddScoped<IClassesRepository, InMemoryClassesRepository>()
            .AddScoped<IGetClassesPresenter, GetClassesConsolePresenter>()
            .AddScoped<IGetClassesUseCase, GetClassesUseCase>()
            //
            .AddScoped<ICountriesRepository, InMemoryCountriesRepository>()
            .AddScoped<IGetCountriesPresenter, GetCountriesConsolePresenter>()
            .AddScoped<IGetCountriesUseCase, GetCountriesUseCase>()

            .BuildServiceProvider();

        //Program starts here
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Chose From the list: ");
        Console.WriteLine("1. Get All Students");
        Console.WriteLine("2. Get All Classes");
        Console.WriteLine("3. Get All Countries");
        Console.WriteLine("--------------------------------");
        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                ListAllStudents(serviceProvider);
                break;
            case "2":
                ListAllClasses(serviceProvider);
                break;
            case "3":
                ListAllCountries(serviceProvider);
                break;
        }

        

    }

    private static void ListAllStudents(ServiceProvider serviceProvider)
    {
        var getAllStudentsUseCase = serviceProvider.GetService<IGetStudentsUseCase>();
        getAllStudentsUseCase!.Execute(serviceProvider.GetService<IGetStudentsPresenter>()!);
    }

    private static void ListAllClasses(ServiceProvider serviceProvider)
    {
        var getAllClassesUseCase = serviceProvider.GetService<IGetClassesUseCase>();
        getAllClassesUseCase!.Execute(serviceProvider.GetService<IGetClassesPresenter>()!);
    }
    private static void ListAllCountries(ServiceProvider serviceProvider)
    {
        var getAllCountriesUseCase = serviceProvider.GetService<IGetCountriesUseCase>();
        getAllCountriesUseCase!.Execute(serviceProvider.GetService<IGetCountriesPresenter>()!);
    }

}