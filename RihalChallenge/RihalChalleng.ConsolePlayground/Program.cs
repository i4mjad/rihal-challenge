//TODO: This is a playground for testing the application buisness logic since I still have a small knowledge about Blazor. 
using Microsoft.Extensions.DependencyInjection;


public class Program
{
    public static void Main(string[] args)
    {
        //DI Container
        var serviceProvider = new ServiceCollection()          
            .AddSingleton<IFooService, BooService>()
            .BuildServiceProvider();

        //Program starts here
        var foo = serviceProvider.GetService<IFooService>();
        foo.DoSomething();

        

    }
}

//TODO: For testing purposes, to be deleted
interface IFooService
{
    void DoSomething();
}

public class FooService : IFooService
{
    public void DoSomething()
    {
        Console.WriteLine("Hello World");
    }
}

public class BooService : IFooService
{
    public void DoSomething()
    {
        Console.WriteLine("Welcome to Rihal");
    }
}