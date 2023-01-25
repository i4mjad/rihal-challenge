using Fluxor;
using Microsoft.OpenApi.Models;
using RihalChallenge.Client.Presenters;
using RihalChallenge.Data;
using RihalChallenge.Domain.DataSources;
using RihalChallenge.Domain.Repositories;
using RihalChallenge.Domain.Repositories.InMemory;
using RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<IInMemoryDataSource, InMemoryDataSource>();
builder.Services.AddSingleton<IGetStudentsUseCase, GetStudentsUseCase>();
builder.Services.AddSingleton<IStudentsRepository, InMemoryStudentsRepository>();
builder.Services.AddScoped<IGetStudentsUseCase, GetStudentsUseCase>();
builder.Services.AddSingleton<IGetStudentBlazorPresenter, GetStudentsGetStudentBlazorPresenter>();
// builder.Services.AddSingleton(typeof(IBlazorPresenter<>), typeof());
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Test", Version = "v1" });
});

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
