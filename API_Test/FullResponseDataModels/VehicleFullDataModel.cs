using API_Test.DataModels;

namespace API_Test.FullResponseDataModels;

public class VehicleFullDataModel : IFullDataModel
{
    public int count { get; set; }
    public string next { get; set; }
    public string previous { get; set; }
    public List<VehicleDataModel> results { get; set; }

    public void RecordResults()
    {
        foreach (var item in results)
        {

        }
    }
}
