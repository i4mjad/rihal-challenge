namespace RihalChallenge.Client.Store.Statistics.GetStudentsAgeAverage;

public class GetStudentsAgeAverageAction
{
}

public class GetStudentsAgeAverageResultAction
{
    public GetStudentsAgeAverageResultAction(int average)
    {
        Average = average;
    }

    public int Average { get; }
}