using API_Test.DataModels;

namespace API_Test.FullResponseDataModels;

public class FilmFullDataModel : IFullDataModel
{
    public int count { get; set; }
    public string next { get; set; }
    public string previous { get; set; }
    public List<FilmDataModel> results { get; set; }

    public void RecordResults(bool isNextNull)
    {
        Globals.FullFilmResults.Add(results);
        if (isNextNull)
        {
            List<FilmDataModel> finalFilmRecords = Globals.FullFilmResults.SelectMany(x => x).OrderBy(x => x.episode_id).ToList();

            Helper.WriteDataToCSV(finalFilmRecords, @"../../../CSV_Files/FilmData.csv");
        }
    }
}
