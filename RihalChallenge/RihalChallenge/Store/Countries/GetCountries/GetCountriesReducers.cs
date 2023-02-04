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
            state.SelectedStudent,
            null,
            null,
            null,
            null,
            null,
            null,
            null);
    }
    
    [ReducerMethod]
    public static StateStore ReduceGetCountriesSuccessAction(StateStore state, GetCountriesResultAction action) =>
        new StateStore(            null,
            false,
            state.SelectedStudent,
            null,
            null,
            action.Countries,
            null,null,null,null);

}