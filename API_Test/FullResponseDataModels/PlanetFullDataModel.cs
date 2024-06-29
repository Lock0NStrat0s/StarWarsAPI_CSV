using API_Test.DataModels;

namespace API_Test.FullResponseDataModels;

public class PlanetFullDataModel : IFullDataModel
{
    public int count { get; set; }
    public string next { get; set; }
    public string previous { get; set; }
    public List<PlanetDataModel> results { get; set; }

    public void RecordResults(bool isNextNull)
    {
        Globals.FullPlanetResults.Add(results);
        if (isNextNull)
        {
            List<PlanetDataModel> finalPlanetRecords = Globals.FullPlanetResults.SelectMany(x => x).ToList();
            Helper.WriteDataToCSV(finalPlanetRecords, @"../../../CSV_Files/PlanetData.csv");
        }
    }
}
