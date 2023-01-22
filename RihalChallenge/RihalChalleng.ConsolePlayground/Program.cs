//TODO: This is a playground for testing the application business logic since I still have a small knowledge about Blazor. 

using Microsoft.Extensions.DependencyInjection;
using RihalChallenge.ConsolePlayground.Presenters;
using RihalChallenge.Domain.DataSources;
using RihalChallenge.Domain.Repositories;
using RihalChallenge.Domain.Repositories.InMemory;
using RihalChallenge.Domain.UseCases.Classes.GetClassesUseCase;
using RihalChallenge.Domain.UseCases.Countries.GetCountriesUseCase;
using RihalChallenge.Domain.UseCases.Students.AddStudentUseCase;
using RihalChallenge.Domain.UseCases.Students.DeleteStudentUseCase;
using RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;
using RihalChallenge.Domain.UseCases.Students.UpdateStudentUseCase;
using RihalRihalChallenge.Domain.UseCases.Countries.GetCountriesUseCase;

namespace RihalChallenge.ConsolePlayground;

public class Program
{
    public static void Main(string[] args)
    {
        //TODO: consider creating a generic presenter interface instead of creating presenters for each use case
        //DI Container
        var serviceProvider = new ServiceCollection()
            //In-Memory Data set
            .AddSingleton<IInMemoryDataSource, InMemoryDataSource>()
            //
            .AddSingleton<IStudentsRepository, InMemoryStudentsRepository>()
            .AddScoped<IGetStudentsPresenter, GetStudentsConsolePresenter>()
            .AddScoped<IGetStudentsUseCase, GetStudentsUseCase>()
            //
            .AddSingleton<IClassesRepository, InMemoryClassesRepository>()
            .AddScoped<IGetClassesPresenter, GetClassesConsolePresenter>()
            .AddScoped<IGetClassesUseCase, GetClassesUseCase>()
            //
            .AddSingleton<ICountriesRepository, InMemoryCountriesRepository>()
            .AddScoped<IGetCountriesPresenter, GetCountriesConsolePresenter>()
            .AddScoped<IGetCountriesUseCase, GetCountriesUseCase>()
            //
            .AddScoped<IAddStudentPresenter, AddStudentConsolePresenter>()
            .AddScoped<IAddStudentUseCase, AddStudentUseCase>()
            //
            .AddScoped<IUpdateStudentPresenter, UpdateStudentConsolePresenter>()
            .AddScoped<IUpdateStudentUseCase, UpdateStudentUseCase>()

            //
            .AddScoped<IDeleteStudentPresenter, DeleteStudentConsolePresenter>()
            .AddScoped<IDeleteStudentUseCase, DeleteStudentUseCase>()


            .BuildServiceProvider();

        //Program starts here
        while (true)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Chose From the list: ");
            Console.WriteLine("1. Get All Students");
            Console.WriteLine("2. Get All Classes");
            Console.WriteLine("3. Get All Countries");
            Console.WriteLine("4. Add student");
            Console.WriteLine("5. Update student");
            Console.WriteLine("6. Delte student");
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
                case "4":
                    AddStudent(serviceProvider);
                    break;
                case "5":
                    UpdateStudent(serviceProvider);
                    break;
                case "6":
                    DeleteStudent(serviceProvider);
                    break;


            }
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
    private static void AddStudent(ServiceProvider serviceProvider)
    {
        Console.WriteLine("Enter Name of the student");
        var nameInput = Console.ReadLine();
        
        Console.WriteLine("Enter Name of the student's class Id");
        var classIdInput = Console.ReadLine();
        
        Console.WriteLine("Enter Name of the student's country Id");
        var countryIdInput = Console.ReadLine();

        var request = new AddStudentRequest(nameInput!,countryIdInput!,classIdInput!);
        
        var addStudentUseCase = serviceProvider.GetService<IAddStudentUseCase>();
       
        addStudentUseCase!.Execute(request,serviceProvider.GetService<IAddStudentPresenter>()!);
    }
    
    private static void DeleteStudent(ServiceProvider serviceProvider)
    {
        Console.WriteLine("Enter student Id");
        var studentIdInput = Console.ReadLine();
        
        var request = new DeleteStudentRequest(Guid.Parse(studentIdInput!));
        
        var deleteStudentUseCase = serviceProvider.GetService<IDeleteStudentUseCase>();
       
        deleteStudentUseCase!.Execute(request,serviceProvider.GetService<IDeleteStudentPresenter>()!);
    }

    private static void UpdateStudent(ServiceProvider serviceProvider)
    {
        Console.WriteLine("Enter Id of the student");
        var idInput = Console.ReadLine();

        Console.WriteLine("Enter Name of the student");
        var nameInput = Console.ReadLine();

        Console.WriteLine("Enter Name of the student's class");
        var classInput = Console.ReadLine();

        Console.WriteLine("Enter Name of the student's country");
        var countryInput = Console.ReadLine();


        //FOR TESTING PURPOSES
        //Humaid: 472e3f1b-08a4-4e02-864e-a4283f576723
        //Amjad: 7e97c858-113c-4214-b9c4-626858f2d8e3
        var request = new UpdateStudentRequest(Guid.Parse(idInput!), nameInput!, countryInput!, classInput!);

        var updateStudentUseCase = serviceProvider.GetService<IUpdateStudentUseCase>();
        updateStudentUseCase!.Execute(request, serviceProvider.GetService<IUpdateStudentPresenter>()!);
    }

}