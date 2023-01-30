using RihalChallenge.Client.Models.Countries;

namespace RihalChallenge.Client.Store.Countries.GetCountries;


public class GetCountriesResultAction
{
    public IEnumerable<Country> Countries { get; }

    public GetCountriesResultAction(IEnumerable<Country> countries)
    {
        Countries = countries;
    }
}

public class GetCountriesAction
{
}

