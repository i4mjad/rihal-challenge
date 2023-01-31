using System.Data;
using Fluxor;
using RihalChallenge.Client.Extensions;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Domain.DataSources;
using RihalChallenge.Domain.Repositories;
using RihalChallenge.Domain.Repositories.InMemory;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//TODO: this is going to be change to sqlite implementation of each repository
builder.Services.AddSingleton<IInMemoryDataSource, InMemoryDataSource>();
builder.Services.AddSingleton<IStudentsRepository, InMemoryStudentsRepository>();
builder.Services.AddSingleton<IClassesRepository, InMemoryClassesRepository>();
builder.Services.AddSingleton<ICountriesRepository, InMemoryCountriesRepository>();
//builder.Services.AddScoped<IDbConnection>();
builder.Services.AddSingleton(typeof(IBlazorPresenter<>), typeof(BlazorPresenter<>));

builder.Services.RegisterUseCases();

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


app.Run();