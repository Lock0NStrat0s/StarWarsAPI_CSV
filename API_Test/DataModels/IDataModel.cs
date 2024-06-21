using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Test.DataModels;

internal interface IDataModel
{
    public string ResponseName { get;} 
    void Display();
}
