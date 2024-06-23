using API_Test.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Test.FullResponseDataModels
{
    internal class StarshipFullDataModel : IFullDataModel<StarshipDataModel>
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<StarshipDataModel> results { get; set; }
        public string ResponseName { get => "starships"; }
    }
}
