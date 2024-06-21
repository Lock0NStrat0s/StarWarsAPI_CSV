using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Test.DataModels;
using Newtonsoft.Json;

namespace API_Test;

internal static class DataModelFactory
{
    public static IDataModel GetDataModelType(string dataType)
    {
        switch (dataType.ToLower())
        {
            case "1":
                return new PeopleDataModel();
            case "4":
                return new FilmDataModel();
            case "3":
                return new StarshipDataModel();
            case "6":
                return new VehicleDataModel();
            case "5":
                return new SpeciesDataModel();
            case "2":
                return new PlanetDataModel();
            default:
                return null;
        }
    }
    public static IDataModel GetModelInfo(string data, IDataModel dataModel)
    {
        switch (dataModel.ResponseName)
        {
            case "people":
                return JsonConvert.DeserializeObject<PeopleDataModel>(data);
            case "films":
                return JsonConvert.DeserializeObject<FilmDataModel>(data);
            case "starships":
                return JsonConvert.DeserializeObject<StarshipDataModel>(data);
            case "vehicles":
                return JsonConvert.DeserializeObject<VehicleDataModel>(data);
            case "species":
                return JsonConvert.DeserializeObject<SpeciesDataModel>(data);
            case "planets":
                return JsonConvert.DeserializeObject<PlanetDataModel>(data);
            default:
                return null;
        }
    }
}
