namespace API_Test.FullResponseDataModels;

public interface IFullDataModel
{
    public int count { get; set; }
    public string next { get; set; }
    public string previous { get; set; }
    public void RecordResults();
}
