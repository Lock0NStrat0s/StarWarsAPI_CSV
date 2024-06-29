using API_Test.DataModels;

namespace API_Test.FullResponseDataModels;

public class StarshipFullDataModel : IFullDataModel
{
    public int count { get; set; }
    public string next { get; set; }
    public string previous { get; set; }
    public List<StarshipDataModel> results { get; set; }

    public void RecordResults(bool isNextNull)
    {
        Globals.FullStarshipResults.Add(results);
        if (isNextNull)
        {
            List<StarshipDataModel> StarshipPeopleRecords = Globals.FullStarshipResults.SelectMany(x => x).ToList();

            Helper.WriteDataToCSV(StarshipPeopleRecords, @"../../../CSV_Files/StarshipData.csv");
        }
    }
}
