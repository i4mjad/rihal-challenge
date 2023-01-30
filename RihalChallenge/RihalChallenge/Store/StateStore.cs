using Fluxor;
using RihalChallenge.Client.Models;
using RihalChallenge.Client.Models.Classes;
using RihalChallenge.Client.Models.Countries;
using RihalChallenge.Client.Models.Statistics;
using RihalChallenge.Client.Models.Students;

namespace RihalChallenge.Client.Store;

[FeatureState]
public class StateStore
{
    public StateStore()
    {
    } // Required for creating initial state

    public IEnumerable<Student>? Students { get; } 
    public Student? SelectedStudent { get; } 
    public bool? IsLoading { get; }
    
    public IEnumerable<Class>? Classes { get; } 
    public Class? SelectedClass { get; }
    
    public IEnumerable<Country>? Countries { get; } 
    public Country? SelectedCountry { get; }
    public IEnumerable<ClassStatistics>? ClassesStatistics { get; }
    public IEnumerable<CountryStatistics>? CountriesStatistics { get; }
    public int? StudentsAgeAverage { get; }



    public StateStore(IEnumerable<Student>? students, bool? isLoading, Student? selectedStudent, Class? selectedClass, IEnumerable<Class>? classes, IEnumerable<Country>? countries, Country? selectedCountry, IEnumerable<ClassStatistics>? classesStatistics, IEnumerable<CountryStatistics>? countriesStatistics, int? studentsAgeAverage)
    {
        Students = students;
        IsLoading = isLoading;
        SelectedStudent = selectedStudent;
        SelectedClass = selectedClass;
        Classes = classes;
        Countries = countries;
        SelectedCountry = selectedCountry;
        ClassesStatistics = classesStatistics;
        CountriesStatistics = countriesStatistics;
        StudentsAgeAverage = studentsAgeAverage;
    }
}