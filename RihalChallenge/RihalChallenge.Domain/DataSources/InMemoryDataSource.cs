using RihalChallenge.Domain.DataModels;

namespace RihalChallenge.Domain.DataSources;

public class InMemoryDataSource: IInMemoryDataSource
{
    private static List<StudentDataModel> _studentDataModels = new List<StudentDataModel>() {       
        new StudentDataModel()
        {
            Id = Guid.Parse("472e3f1b-08a4-4e02-864e-a4283f576723"),
            ClassId = Guid.Parse("55e42c1f-2988-4db6-8e37-3a86d7798a67"),
            Name = "Humaid",
            CountryId = Guid.Parse("42c98f75-ab9b-4a37-8047-7c09648f7971"),
            DayOfBirth = new DateTime(1998, 08, 28)
        },
        new StudentDataModel()
        {
            Id = Guid.Parse("7e97c858-113c-4214-b9c4-626858f2d8e3"),
            ClassId = Guid.Parse("b2933bde-d8b9-46ce-b031-c748096368d8"),
            Name = "Amjad",
            CountryId = Guid.Parse("00304ceb-e0fc-47df-b14b-7c9023f6cf2e"),
            DayOfBirth = new DateTime(1998, 05, 02)
        },};

    private static List<ClassDataModel> _classDataModels = new List<ClassDataModel>()
    {
        new ClassDataModel()
        {
            Id = Guid.Parse("55e42c1f-2988-4db6-8e37-3a86d7798a67"),

            Name = "History",
        },
        new ClassDataModel()
        {
            Id = Guid.Parse("b2933bde-d8b9-46ce-b031-c748096368d8"),

            Name = "Math",
        },

    };
    
    private static List<CountryDataModel> _countryDataModels = new List<CountryDataModel>()
    {
        new CountryDataModel()
        {
            Id = Guid.Parse("42c98f75-ab9b-4a37-8047-7c09648f7971"),
            Name = "Oman"
        },
        new CountryDataModel()
        {
            Id = Guid.Parse("00304ceb-e0fc-47df-b14b-7c9023f6cf2e"),
            Name = "Qatar",
        },

    };
    public DataSet<StudentDataModel> StudentsDataSet() => new()
    {
        Items = _studentDataModels
    };
        
    
    public DataSet<ClassDataModel> ClassDataSet() => new()
    {
        Items = _classDataModels
    };

    public DataSet<CountryDataModel> CountryDataSet() => new()
    {
        Items = _countryDataModels
    };
}