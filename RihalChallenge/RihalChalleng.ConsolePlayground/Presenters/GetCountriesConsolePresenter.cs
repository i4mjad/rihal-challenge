using RihalChallenge.Domain.UseCases.Countries.GetCountriesUseCase;

namespace RihalChallenge.ConsolePlayground.Presenters;

public class GetCountriesConsolePresenter: IGetCountriesPresenter
{
    public void Success(GetCountriesResponse response)
    {
        var allCountries = response.Countries;
        foreach (var country in allCountries)
        {
            Console.WriteLine($"Id: {country.Id}, Class: {country.Name}");
        }
    }

    public void Error(string error)
    {
        throw new NotImplementedException();
    }
}