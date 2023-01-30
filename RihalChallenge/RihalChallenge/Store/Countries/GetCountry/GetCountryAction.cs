using RihalChallenge.Client.Models;
using RihalChallenge.Client.Models.Classes;
using RihalChallenge.Client.Models.Countries;

namespace RihalChallenge.Client.Store.Countries.GetCountry;

public class GetCountryResultAction
{
    public Country Country { get; }

    public GetCountryResultAction(Country country)
    {
        Country = country;
    }
}

public class GetCountryAction
{
    public GetCountryAction(Guid studentId)
    {
        CountryId = studentId;
    }

    public Guid CountryId { get; }
}