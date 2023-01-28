using System.Diagnostics;
using RihalChallenge.Domain.UseCases.Classes.GetClassesUseCase;
using RihalChallenge.Domain.UseCases.Countries.GetCountriesUseCase;
using RihalChallenge.Domain.UseCases.Students.AddStudentUseCase;
using RihalChallenge.Domain.UseCases.Students.DeleteStudentUseCase;
using RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;
using RihalChallenge.Domain.UseCases.Students.GetStudentUseCase;
using RihalChallenge.Domain.UseCases.Students.UpdateStudentUseCase;
using GetStudentsUseCase = RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase.GetStudentsUseCase;

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
        services.AddTransient<IGetStudentUseCase, GetStudentUseCase>();
        
        //Classes
        services.AddTransient<IGetClassesUseCase, GetClassesUseCase>();

        //Countries
        services.AddTransient<IGetCountriesUseCase, GetCountriesUseCase>();
        
        return services;
    }
}

