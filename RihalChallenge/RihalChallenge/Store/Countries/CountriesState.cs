using Fluxor;

namespace RihalChallenge.Client.Stores.Countries;

[FeatureState]
public class CountriesState
{
    public CountriesState() { } // Required for creating initial state

    public IEnumerable<Country>? Countries { get; } 
    public bool? IsLoading { get; }



    public CountriesState(IEnumerable<Country>? countries, bool? isLoading)
    {
        Countries = countries;
        IsLoading = isLoading;
    }
}

//TODO: Move to model folder

public class Country
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}