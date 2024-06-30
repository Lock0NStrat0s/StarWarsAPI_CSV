namespace StarWarsAPI.FullResponseDataModels;

// Interface for the full data model
public interface IFullDataModel
{
    public int count { get; set; }              // Number of records
    public string next { get; set; }            // Next page
    public string previous { get; set; }        // Previous page
    public void RecordResults(bool isNextNull); // Record the results
}
