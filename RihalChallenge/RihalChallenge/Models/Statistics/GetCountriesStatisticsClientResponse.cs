namespace RihalChallenge.Client.Models.Statistics;

public record GetCountriesStatisticsClientResponse(IEnumerable<CountryStatistics> CountriesStatistics);