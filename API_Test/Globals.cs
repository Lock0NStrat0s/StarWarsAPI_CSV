using API_Test.DataModels;

namespace API_Test;

// Global variables to store combine full response records
public static class Globals
{
    public static List<List<FilmDataModel>> FullFilmResults { get; set; } = new List<List<FilmDataModel>>();
    public static List<List<PeopleDataModel>> FullPeopleResults { get; set; } = new List<List<PeopleDataModel>>();
    public static List<List<PlanetDataModel>> FullPlanetResults { get; set; } = new List<List<PlanetDataModel>>();
    public static List<List<SpeciesDataModel>> FullSpeciesResults { get; set; } = new List<List<SpeciesDataModel>>();
    public static List<List<StarshipDataModel>> FullStarshipResults { get; set; } = new List<List<StarshipDataModel>>();
    public static List<List<VehicleDataModel>> FullVehicleResults { get; set; } = new List<List<VehicleDataModel>>();
}
