using RihalChallenge.Domain.Entities;

namespace RihalChallenge.Domain.UseCases.Statistics.GetCountriesStatistics;

public record GetCountriesStatisticsResponse(IEnumerable<CountryStatistics> CountriesStatistics);