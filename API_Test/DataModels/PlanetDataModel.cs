using CsvHelper.Configuration;

namespace API_Test.DataModels;

public class PlanetDataModel : IDataModel
{
    public string name { get; set; }
    public string rotation_period { get; set; }
    public string orbital_period { get; set; }
    public string diameter { get; set; }
    public string climate { get; set; }
    public string gravity { get; set; }
    public string terrain { get; set; }
    public string surface_water { get; set; }
    public string population { get; set; }
    public List<string> residents { get; set; }
    public List<string> films { get; set; }
    public DateTime created { get; set; }
    public DateTime edited { get; set; }
    public string url { get; set; }
    public void Display()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Rotation Period: {rotation_period}");
        Console.WriteLine($"Orbital Period:  {orbital_period}");
        Console.WriteLine($"Diameter: {diameter}");
        Console.WriteLine($"Climate: {climate}");
        Console.WriteLine($"Gravity: {gravity}");
        Console.WriteLine($"Terrain: {terrain}");
        Console.WriteLine($"Surface Water: {surface_water}");
        Console.WriteLine($"Population: {population}");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
    }
    public string Films => (films != null && films.Any()) ? string.Join("; ", films.Select(a => a)) : string.Empty;
    public string Residents => (residents != null && residents.Any()) ? string.Join("; ", residents.Select(a => a)) : string.Empty;
}

// Map the data model to the csv file
public class PlanetDataModelMap : ClassMap<PlanetDataModel>
{
    public PlanetDataModelMap()
    {
        Map(m => m.name);
        Map(m => m.rotation_period);
        Map(m => m.orbital_period);
        Map(m => m.diameter);
        Map(m => m.climate);
        Map(m => m.gravity);
        Map(m => m.terrain);
        Map(m => m.surface_water);
        Map(m => m.population);

        Map(m => m.Films);
        Map(m => m.Residents);

        Map(m => m.url);
        Map(m => m.created);
        Map(m => m.edited);
    }
}

