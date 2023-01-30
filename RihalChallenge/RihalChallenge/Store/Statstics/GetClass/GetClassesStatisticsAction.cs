using RihalChallenge.Client.Models.Classes;
using RihalChallenge.Client.Models.Statistics;

namespace RihalChallenge.Client.Store.Statstics.GetClass;

public class GetClassesStatisticsAction
{
}

public class GetClassesStatisticsResultAction
{
    public GetClassesStatisticsResultAction(IEnumerable<ClassStatistics> classesStatistics)
    {
        ClassesStatistics = classesStatistics;
    }

    public IEnumerable<ClassStatistics> ClassesStatistics { get; set; }
}