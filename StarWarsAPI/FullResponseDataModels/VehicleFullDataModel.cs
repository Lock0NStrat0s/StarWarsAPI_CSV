using StarWarsAPI;
using StarWarsAPI.DataModels;

namespace StarWarsAPI.FullResponseDataModels;

public class VehicleFullDataModel : IFullDataModel
{
    public int count { get; set; }
    public string next { get; set; }
    public string previous { get; set; }
    public List<VehicleDataModel> results { get; set; }

    public void RecordResults(bool isNextNull)
    {
        Globals.FullVehicleResults.Add(results);
        if (isNextNull)
        {
            List<VehicleDataModel> finalVehicleRecords = Globals.FullVehicleResults.SelectMany(x => x).ToList();

            Helper.WriteDataToCSV(finalVehicleRecords, @"../../../CSV_Files/VehicleData.csv");
        }
    }
}
