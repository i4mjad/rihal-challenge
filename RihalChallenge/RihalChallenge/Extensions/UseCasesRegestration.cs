using System.Diagnostics;
using RihalChallenge.Domain.UseCases.Classes.GetClassesUseCase;
using RihalChallenge.Domain.UseCases.Countries.GetCountriesUseCase;
using RihalChallenge.Domain.UseCases.Students.AddStudentUseCase;
using RihalChallenge.Domain.UseCases.Students.DeleteStudentUseCase;
using RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;
using RihalChallenge.Domain.UseCases.Students.UpdateStudentUseCase;

namespace RihalChallenge.Client.Extensions;

public static class UseCasesRegistration
{
    public static IServiceCollection RegisterUseCases(this IServiceCollection services)
    {
        //Students
        services.AddTransient<IGetStudentsUseCase, GetStudentsUseCase>();
        services.AddTransient<IUpdateStudentUseCase, UpdateStudentUseCase>();
        services.AddTransient<IDeleteStudentUseCase, DeleteStudentUseCase>();
        services.AddTransient<IAddStudentUseCase, AddStudentUseCase>();
        
        //Classes
        services.AddTransient<IGetClassesUseCase, GetClassesUseCase>();

        //Countries
        services.AddTransient<IGetCountriesUseCase, GetCountriesUseCase>();


        
        
        return services;
    }
}

