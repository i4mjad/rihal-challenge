using RihalChallenge.Domain.Entities;
using RihalChallenge.Domain.Repositories;

namespace RihalChallenge.Domain.UseCases.Statistics.GetCountriesStatistics;

public class GetCountriesStatisticsUseCase:IGetCountriesStatisticsUseCase
{
    private readonly ICountriesRepository _countriesRepository;
    private readonly IStudentsRepository _studentsRepository;

    public GetCountriesStatisticsUseCase(ICountriesRepository countriesRepository, IStudentsRepository studentsRepository)
    {
        _countriesRepository = countriesRepository;
        _studentsRepository = studentsRepository;
    }
    public async Task Execute(IPresenter<GetCountriesStatisticsResponse> presenter)
    {
        var countries = await _countriesRepository.GetAllCountries();
        var students = await _studentsRepository.GetAllStudents();
        var statisticsList = new List<CountryStatistics>(){};
        foreach (var country in countries)
        {
            var studentsWithCountry = students.ToList().Where(student => student.CountryName == country.CountryName).ToList();
            var countryStatistics = new CountryStatistics(country.CountryName, studentsWithCountry.Count.ToString());
            statisticsList.Add(countryStatistics);
        }
        presenter.Success(new GetCountriesStatisticsResponse(statisticsList));
    }
}