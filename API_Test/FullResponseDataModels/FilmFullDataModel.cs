using API_Test.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Test.FullResponseDataModels
{
    internal class FilmFullDataModel : IFullDataModel<FilmDataModel>
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<FilmDataModel> results { get; set; }
        public string ResponseName { get => "films"; }
    }
}
