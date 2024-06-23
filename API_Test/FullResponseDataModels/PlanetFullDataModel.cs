using API_Test.DataModels;

namespace API_Test.FullResponseDataModels;

public class PlanetFullDataModel : IFullDataModel
{
    public int count { get; set; }
    public string next { get; set; }
    public string previous { get; set; }
    public List<PlanetDataModel> results { get; set; }

    public void RecordResults()
    {
        throw new NotImplementedException();
    }
}
