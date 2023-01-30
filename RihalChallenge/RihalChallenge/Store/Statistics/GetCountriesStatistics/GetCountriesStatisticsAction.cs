using RihalChallenge.Client.Models.Statistics;

namespace RihalChallenge.Client.Store.Statistics.GetCountriesStatistics;

public class GetCountriesStatisticsAction
{
}

public class GetCountriesStatisticsResultAction
{
    public GetCountriesStatisticsResultAction(IEnumerable<CountryStatistics> countriesStatistics)
    {
        CountriesStatistics = countriesStatistics;
    }

    public IEnumerable<CountryStatistics> CountriesStatistics { get; set; }
}