using CsvHelper.Configuration;

namespace API_Test.DataModels;

public class FilmDataModel : IDataModel
{
    public string title { get; set; }
    public int episode_id { get; set; }
    public string opening_crawl { get; set; }
    public string director { get; set; }
    public string producer { get; set; }
    public string release_date { get; set; }
    public List<string> characters { get; set; }
    public List<string> planets { get; set; }
    public List<string> starships { get; set; }
    public List<string> vehicles { get; set; }
    public List<string> species { get; set; }
    public DateTime created { get; set; }
    public DateTime edited { get; set; }
    public string url { get; set; }
    public void Display()
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Episode ID: {episode_id}");
        Console.WriteLine($"Opening Crawl:\n {opening_crawl}\n");
        Console.WriteLine($"Director: {director}");
        Console.WriteLine($"Producer: {producer}");
        Console.WriteLine($"Release Date: {release_date}");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
    }
    public string Characters => (characters != null && characters.Any()) ? string.Join("; ", characters.Select(a => a)) : string.Empty;
    public string Planets => (planets != null && planets.Any()) ? string.Join("; ", planets.Select(a => a)) : string.Empty;
    public string Starships => (starships != null && starships.Any()) ? string.Join("; ", starships.Select(a => a)) : string.Empty;
    public string Vehicles => (vehicles != null && vehicles.Any()) ? string.Join("; ", vehicles.Select(a => a)) : string.Empty;
    public string Species => (species != null && species.Any()) ? string.Join("; ", species.Select(a => a)) : string.Empty;
}

// Map the data model to the csv file
public class FilmDataModelMap : ClassMap<FilmDataModel>
{
    public FilmDataModelMap()
    {
        Map(m => m.title);
        Map(m => m.episode_id);
        Map(m => m.opening_crawl);
        Map(m => m.director);
        Map(m => m.producer);
        Map(m => m.release_date);
        Map(m => m.Characters);
        Map(m => m.Planets);
        Map(m => m.Starships);
        Map(m => m.Vehicles);
        Map(m => m.Species);
        Map(m => m.created);
        Map(m => m.edited);
        Map(m => m.url);
    }
}
