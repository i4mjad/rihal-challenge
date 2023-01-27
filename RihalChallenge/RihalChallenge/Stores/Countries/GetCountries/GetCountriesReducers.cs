using Fluxor;
using RihalChallenge.Client.Stores.ClassesStore;
using RihalChallenge.Client.Stores.ClassesStore.GetClasses;

namespace RihalChallenge.Client.Stores.Countries.GetCountries;

public static class GetCountriesReducers
{
    [ReducerMethod]
    public static CountriesState ReduceGetCountriesAction(CountriesState state, GetCountriesResultAction action)
    {
        return new CountriesState(isLoading:true, countries:null);
    }
    
    [ReducerMethod]
    public static CountriesState ReduceGetCountriesSuccessAction(CountriesState state, GetCountriesResultAction action) =>
        new CountriesState(isLoading: false, countries: action.Countries);

}