using RihalChallenge.Client.Models;
using RihalChallenge.Client.Models.Countries;

namespace RihalChallenge.Client.Store.Countries.DeleteCountry;

public class DeleteCountryAction
{
    public Guid Id { get; }
    public DeleteCountryAction(Guid id)
    {
        Id = id;
    }
}
public class DeleteCountryResultAction
{
    public IEnumerable<Country> Countries { get; }
    public DeleteCountryResultAction(IEnumerable<Country> countries)
    {
        Countries = countries;
    }
}

