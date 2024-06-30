using StarWarsAPI;
using StarWarsAPI.DataModels;

namespace StarWarsAPI.FullResponseDataModels;

public class PeopleFullDataModel : IFullDataModel
{
    public int count { get; set; }
    public string next { get; set; }
    public string previous { get; set; }
    public List<PeopleDataModel> results { get; set; }

    public void RecordResults(bool isNextNull)
    {
        Globals.FullPeopleResults.Add(results);
        if (isNextNull)
        {
            List<PeopleDataModel> finalPeopleRecords = Globals.FullPeopleResults.SelectMany(x => x).ToList();

            Helper.WriteDataToCSV(finalPeopleRecords, @"../../../CSV_Files/PeopleData.csv");
        }
    }
}
