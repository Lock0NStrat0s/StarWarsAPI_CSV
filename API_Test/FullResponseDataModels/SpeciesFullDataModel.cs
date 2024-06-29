using API_Test.DataModels;

namespace API_Test.FullResponseDataModels;

public class SpeciesFullDataModel : IFullDataModel
{
    public int count { get; set; }
    public string next { get; set; }
    public string previous { get; set; }
    public List<SpeciesDataModel> results { get; set; }

    public void RecordResults(bool isNextNull)
    {
        Globals.FullSpeciesResults.Add(results);
        if (isNextNull)
        {
            List<SpeciesDataModel> finalSpeciesRecords = Globals.FullSpeciesResults.SelectMany(x => x).ToList();

            Helper.WriteDataToCSV(finalSpeciesRecords, @"../../../CSV_Files/SpeciesData.csv");
        }
    }
}
