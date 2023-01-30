using Fluxor;

namespace RihalChallenge.Client.Store.Countries.GetCountries;

public static class GetCountriesReducers
{
    [ReducerMethod]
    public static StateStore ReduceGetCountriesAction(StateStore state, GetCountriesResultAction action)
    {
        return new StateStore(            
            null,
            true,
            null,
            null,
            null
            ,null,
            null);
    }
    
    [ReducerMethod]
    public static StateStore ReduceGetCountriesSuccessAction(StateStore state, GetCountriesResultAction action) =>
        new StateStore(            null,
            false,
            null,
            null,
            state.Classes
            ,action.Countries,
            null);

}