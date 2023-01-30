using Fluxor;


namespace RihalChallenge.Client.Store.Countries.GetCountry;

public static class GetCountryReducers
{
    [ReducerMethod]
    public static StateStore ReduceGetCountryAction(StateStore state, GetCountryAction action)
    {
        return new StateStore(
            null,
            true,
            null,
            null,
            null
            ,null,null,null,null,null);
    }
    
    [ReducerMethod]
    public static StateStore ReduceGetCountrySuccessAction(StateStore state, GetCountryResultAction action) =>
        new StateStore(
            null,
            false,
            null,
            null,
            null,
            null,
            action.Country,null,null,null);

} 