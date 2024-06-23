﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Test.DataModels;

namespace API_Test.FullResponseDataModels;

public class PeopleFullDataModel : IFullDataModel<PeopleDataModel>
{
    public int count { get; set; }
    public string next { get; set; }
    public string previous { get; set; }
    public List<PeopleDataModel> results { get; set; }
    public string ResponseName { get => "people"; }
}
