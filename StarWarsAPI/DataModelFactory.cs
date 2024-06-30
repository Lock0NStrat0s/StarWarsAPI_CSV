using Newtonsoft.Json;
using StarWarsAPI.DataModels;
using StarWarsAPI.FullResponseDataModels;

namespace StarWarsAPI;

// Factory class to create the correct data model based on the data type
public static class DataModelFactory
{
    // Returns data model type
    public static string GetDataModelType(string dataType)
    {
        switch (dataType.ToLower())
        {
            case "1":
                return "people";
            case "2":
                return "planets";
            case "3":
                return "starships";
            case "4":
                return "films";
            case "5":
                return "species";
            case "6":
                return "vehicles";
            default:
                return "null";
        }
    }

    // Returns deserialized data model for full response
    public static IFullDataModel GetFullDeserializedModel(string data, string param)
    {
        switch (param)
        {
            case "people":
                return JsonConvert.DeserializeObject<PeopleFullDataModel>(data);
            case "films":
                return JsonConvert.DeserializeObject<FilmFullDataModel>(data);
            case "starships":
                return JsonConvert.DeserializeObject<StarshipFullDataModel>(data);
            case "vehicles":
                return JsonConvert.DeserializeObject<VehicleFullDataModel>(data);
            case "species":
                return JsonConvert.DeserializeObject<SpeciesFullDataModel>(data);
            case "planets":
                return JsonConvert.DeserializeObject<PlanetFullDataModel>(data);
            default:
                return null;
        }
    }

    // Returns deserialized data model for single response
    public static IDataModel GetSingleDeserializedModel(string data, string param)
    {
        switch (param)
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
