using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Test.DataModels;
using API_Test.FullResponseDataModels;
using Newtonsoft.Json;

namespace API_Test;

internal static class DataModelFactory
{
    public static string GetFullDataModelType(string dataType)
    {
        switch (dataType.ToLower())
        {
            case "1":
                return "people";
            case "2":
                return "People";
            case "3":
                return "People";
            case "4":
                return "People";
            case "5":
                return "People";
            case "6":
                return "People";
            default:
                return "null";
        }
    }
    public static IFullDataModel GetFullDeserializedModel(string data, string param)
    {
        switch (param)
        {
            case "people":
                return JsonConvert.DeserializeObject<PeopleFullDataModel>(data);
            //case "films":
            //    return JsonConvert.DeserializeObject<FilmFullDataModel>(data);
            //case "starships":
            //    return JsonConvert.DeserializeObject<StarshipFullDataModel>(data);
            //case "vehicles":
            //    return JsonConvert.DeserializeObject<VehicleFullDataModel>(data);
            //case "species":
            //    return JsonConvert.DeserializeObject<SpeciesFullDataModel>(data);
            //case "planets":
            //    return JsonConvert.DeserializeObject<PlanetFullDataModel>(data);
            default:
                return null;
        }
    }

    public static IDataModel GetSingleDataModelType(string dataType)
    {
        switch (dataType.ToLower())
        {
            case "1":
                return new PeopleDataModel();
            case "2":
                return new PlanetDataModel();
            case "3":
                return new StarshipDataModel();
            case "4":
                return new FilmDataModel();
            case "5":
                return new SpeciesDataModel();
            case "6":
                return new VehicleDataModel();
            default:
                return null;
        }
    }
    public static IDataModel GetSingleDeserializedModel(string data, IDataModel dataModel)
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
