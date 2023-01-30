using RihalChallenge.Domain.Entities;

namespace RihalChallenge.Domain.UseCases.Statistics.GetClassesStatistics;

public record GetClassesStatisticsResponse(IEnumerable<ClassStatistics> ClassesStatistics);