//TODO: This is a playground for testing the application buisness logic since I still have a small knowledge about Blazor. 
using Microsoft.Extensions.DependencyInjection;
using RihalChallenge.ConsolePlayground;
using RihalChallenge.Domain.DataSources;
using RihalChallenge.Domain.Repositories;
using RihalChallenge.Domain.Repositories.InMemory;
using RihalChallenge.Domain.UseCases.GetStudentsUseCase;


public class Program
{
    public static void Main(string[] args)
    {
        //DI Container
        var serviceProvider = new ServiceCollection()          
            
            .AddScoped<IInMemoryDataSource, InMemoryDataSource>()
            .AddScoped<IStudentsRepository, InMemoryStudentsRepository>()
            .AddScoped<IGetStudentsPresenter, GetStudentsConsolePresenter>()
            .AddScoped<IGetStudentsUseCase, GetStudentsUseCase>()
            .BuildServiceProvider();

        //Program starts here
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Chose From the list: ");
        Console.WriteLine("1. Get All Students");

        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                ListAllUsers();
                break;
        }

        

    }

    public static void ListAllUsers()
    {
        var getAllUsersUseCase = new GetStudentsUseCase(new InMemoryStudentsRepository(new InMemoryDataSource()));
        getAllUsersUseCase.Execute(new GetStudentsConsolePresenter());
    }



}
