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
    public static IFullDataModel<T> GetFullDataModelType<T>(string dataType)
    {
        switch (dataType.ToLower())
        {
            case "1":
                return (IFullDataModel<T>)new PeopleFullDataModel();
            case "2":
                return (IFullDataModel<T>)new PlanetFullDataModel();
            case "3":
                return (IFullDataModel<T>)new StarshipFullDataModel();
            case "4":
                return (IFullDataModel<T>)new FilmFullDataModel();
            case "5":
                return (IFullDataModel<T>)new SpeciesFullDataModel();
            case "6":
                return (IFullDataModel<T>)new VehicleFullDataModel();
            default:
                return null;
        }
    }
    public static IFullDataModel<T> GetFullDeserializedModel<T>(string data, IFullDataModel<T> dataModel)
    {
        switch (dataModel.ResponseName)
        {
            case "people":
                return (IFullDataModel<T>)JsonConvert.DeserializeObject<PeopleFullDataModel>(data);
            case "films":
                return (IFullDataModel<T>)JsonConvert.DeserializeObject<FilmFullDataModel>(data);
            case "starships":
                return (IFullDataModel<T>)JsonConvert.DeserializeObject<StarshipFullDataModel>(data);
            case "vehicles":
                return (IFullDataModel<T>)JsonConvert.DeserializeObject<VehicleFullDataModel>(data);
            case "species":
                return (IFullDataModel<T>)JsonConvert.DeserializeObject<SpeciesFullDataModel>(data);
            case "planets":
                return (IFullDataModel<T>)JsonConvert.DeserializeObject<PlanetFullDataModel>(data);
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
