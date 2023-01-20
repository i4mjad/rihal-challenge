using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RihalChallenge.Domain.DataModels;

namespace RihalChallenge.Domain.DataSources;
public interface IInMemoryDataSource
{
    public DataSet<StudentDataModel> StudentsDataSet();
    public DataSet<ClassDataModel> ClassDataSet();
    public DataSet<CountryDataModel> CountryDataSet();
}