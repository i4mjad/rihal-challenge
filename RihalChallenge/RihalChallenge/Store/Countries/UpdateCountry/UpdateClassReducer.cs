using Fluxor;


namespace RihalChallenge.Client.Store.Countries.UpdateCountry;

public static class UpdateCountryReducer
{
    [ReducerMethod]
    public static StateStore ReduceUpdateCountryAction(StateStore state, UpdateCountryAction action)
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
    public static StateStore ReduceUpdateCountryResultAction(StateStore state, UpdateCountryResultAction action)
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