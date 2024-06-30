using CsvHelper.Configuration;

namespace StarWarsAPI.DataModels;

public class SpeciesDataModel : IDataModel
{
    public string name { get; set; }
    public string classification { get; set; }
    public string designation { get; set; }
    public string average_height { get; set; }
    public string skin_colors { get; set; }
    public string hair_colors { get; set; }
    public string eye_colors { get; set; }
    public string average_lifespan { get; set; }
    public string homeworld { get; set; }
    public string language { get; set; }
    public List<string> people { get; set; }
    public List<string> films { get; set; }
    public DateTime created { get; set; }
    public DateTime edited { get; set; }
    public string url { get; set; }
    public void Display()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Classification: {classification}");
        Console.WriteLine($"Designation:  {designation}");
        Console.WriteLine($"AVG Height: {average_height}");
        Console.WriteLine($"Skin Colors: {skin_colors}");
        Console.WriteLine($"Hair Colors: {hair_colors}");
        Console.WriteLine($"Eye Colors: {eye_colors}");
        Console.WriteLine($"AVG Lifespan: {average_lifespan}");
        Console.WriteLine($"Language: {language}");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
    }
    public string Films => films != null && films.Any() ? string.Join("; ", films.Select(a => a)) : string.Empty;
    public string People => people != null && people.Any() ? string.Join("; ", people.Select(a => a)) : string.Empty;
}

// Map the data model to the csv file
public class SpeciesDataModelMap : ClassMap<SpeciesDataModel>
{
    public SpeciesDataModelMap()
    {
        Map(m => m.name);
        Map(m => m.classification);
        Map(m => m.designation);
        Map(m => m.average_height);
        Map(m => m.skin_colors);
        Map(m => m.hair_colors);
        Map(m => m.eye_colors);
        Map(m => m.average_lifespan);
        Map(m => m.homeworld);
        Map(m => m.language);

        Map(m => m.Films);
        Map(m => m.People);

        Map(m => m.url);
        Map(m => m.created);
        Map(m => m.edited);
    }
}

