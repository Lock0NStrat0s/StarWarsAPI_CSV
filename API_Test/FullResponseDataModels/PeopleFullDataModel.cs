using API_Test.DataModels;

namespace API_Test.FullResponseDataModels;

public class PeopleFullDataModel : IFullDataModel
{
    public int count { get; set; }
    public string next { get; set; }
    public string previous { get; set; }
    public List<PeopleDataModel> results { get; set; }

    public void PrintResults()
    {
        foreach (var item in results)
        {
            // Print Whatever you want//
        }
    }

    public string ReturnResponseName() => "people";

}
