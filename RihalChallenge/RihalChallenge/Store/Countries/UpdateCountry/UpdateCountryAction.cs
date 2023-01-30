namespace RihalChallenge.Client.Store.Countries.UpdateCountry;

public class UpdateCountryAction
{
    public UpdateCountryAction(Guid countryId, string name)
    {
        CountryId = countryId;
        Name = name;
    }

    public Guid CountryId { get; }

    public string Name { get; }
}
public class UpdateCountryResultAction
{
}

