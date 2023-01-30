using Fluxor;

namespace RihalChallenge.Client.Store.Countries.DeleteCountry;

public static class DeleteCountryReducer
{
    [ReducerMethod]
    public static StateStore ReduceDeleteCountryAction(StateStore state, DeleteCountryAction action)
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
    public static StateStore ReduceDeleteCountryResultAction(StateStore state, DeleteCountryResultAction action)
    {
        return new StateStore(
            null,
            false,
            null,
            null,
            null
            ,action.Countries,null);
    }
}