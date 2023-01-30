namespace RihalChallenge.Client.Store.Countries.AddCountry;

public class AddCountryAction
{
    public AddCountryAction(string name)
    {
        Name = name;
    }

    public string Name { get; }

}
public class AddCountryResultAction
{
}

