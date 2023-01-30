using Fluxor;
namespace RihalChallenge.Client.Store.Countries.AddCountry;

public static class AddCountryReducer
{
    [ReducerMethod]
    public static StateStore ReduceAddCountryAction(StateStore state, AddCountryAction action)
    {
        return new StateStore(
            null,
            true,
            null,
            null,
            null
            ,null,null);
    }

    [ReducerMethod]
    public static StateStore ReduceAddCountryResultAction(StateStore state, AddCountryResultAction action)
    {
        return new StateStore(
            null,
            false,
            null,
            null,
            null
            ,null,null);
    }
}