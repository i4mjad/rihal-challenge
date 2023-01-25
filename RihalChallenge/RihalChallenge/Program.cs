using System.Reflection;
using Fluxor;
using Microsoft.OpenApi.Models;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Data;
using RihalChallenge.Domain.DataSources;
using RihalChallenge.Domain.Repositories;
using RihalChallenge.Domain.Repositories.InMemory;
using RihalChallenge.Domain.UseCases;
using RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<IInMemoryDataSource, InMemoryDataSource>();
//TODO: I'm experimenting using one interface for all use cases
//builder.Services.AddSingleton<IGetStudentsUseCase, GetStudentsUseCase>();
builder.Services.AddSingleton<IStudentsRepository, InMemoryStudentsRepository>();
builder.Services.AddSingleton(typeof(IBlazorPresenter<>), typeof(BlazorPresenter<>));


builder.Services.AddAllGenericTypes(typeof(IUseCase<,>), new[] { typeof(GetStudentsUseCase).GetTypeInfo().Assembly });


builder.Services.AddFluxor(o =>
{
    o.ScanAssemblies(typeof(Program).Assembly);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.Run();


public static class ServiceCollectionExtentions
{
    public static void AddAllTypes<T>(this IServiceCollection services
        , Assembly[] assemblies
        , bool additionalRegisterTypesByThemself = false
        , ServiceLifetime lifetime = ServiceLifetime.Transient
    )
    {
        var typesFromAssemblies = assemblies.SelectMany(a =>
            a.DefinedTypes.Where(x => x.GetInterfaces().Any(i => i == typeof(T))));
        foreach (var type in typesFromAssemblies)
        {
            services.Add(new ServiceDescriptor(typeof(T), type, lifetime));
            if (additionalRegisterTypesByThemself)
                services.Add(new ServiceDescriptor(type, type, lifetime));
        }
    }

    public static void AddAllGenericTypes(this IServiceCollection services
        , Type t
        , Assembly[] assemblies
        , bool additionalRegisterTypesByThemself = false
        , ServiceLifetime lifetime = ServiceLifetime.Transient
    )
    {
        var genericType = t;
        var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces()
            .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == genericType)));

        foreach (var type in typesFromAssemblies)
        {
            services.Add(new ServiceDescriptor(t, type, lifetime));
            if (additionalRegisterTypesByThemself)
                services.Add(new ServiceDescriptor(type, type, lifetime));
        }
    }
}