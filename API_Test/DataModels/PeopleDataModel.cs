using CsvHelper.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace API_Test.DataModels;

public class PeopleDataModel : IDataModel
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("birth_year")]
    public string BirthYear { get; set; }
    [JsonProperty("eye_color")]
    public string EyeColor { get; set; }
    [JsonProperty("gender")]
    public string Gender { get; set; }
    [JsonProperty("hair_color")]
    public string HairColor { get; set; }
    [JsonProperty("height")]
    public string Height { get; set; }
    [JsonProperty("mass")]
    public string Mass { get; set; }
    [JsonProperty("skin_color")]
    public string SkinColor { get; set; }
    [JsonProperty("homeworld")]
    public string Homeworld { get; set; }

    public List<string> films { get; set; }
    public List<string> species { get; set; }
    public List<string> starships { get; set; }
    public List<string> vehicles { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }
    [JsonProperty("created")]
    public DateTime Created { get; set; }
    [JsonProperty("edited")]
    public DateTime Edited { get; set; }
    public void Display()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Birth Year: {BirthYear}");
        Console.WriteLine($"Eye Color: {EyeColor}");
        Console.WriteLine($"Gender: {Gender}");
        Console.WriteLine($"Hair Color: {HairColor}");
        Console.WriteLine($"Height: {Height}");
        Console.WriteLine($"Mass: {Mass}");
        Console.WriteLine($"Skin Color: {SkinColor}");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
    }
    public string Films => (films != null && films.Any()) ? string.Join("; ", films.Select(a => a)) : string.Empty;
    public string Starships => (starships != null && starships.Any()) ? string.Join("; ", starships.Select(a => a)) : string.Empty;
    public string Vehicles => (vehicles != null && vehicles.Any()) ? string.Join("; ", vehicles.Select(a => a)) : string.Empty;
    public string Species => (species != null && species.Any()) ? string.Join("; ", species.Select(a => a)) : string.Empty;
}

public class PeopleDataModelMap : ClassMap<PeopleDataModel>
{
    public PeopleDataModelMap()
    {
        Map(m => m.Name);
        Map(m => m.BirthYear);
        Map(m => m.EyeColor);
        Map(m => m.Gender);
        Map(m => m.HairColor);
        Map(m => m.Height);
        Map(m => m.Mass);
        Map(m => m.SkinColor);
        Map(m => m.Homeworld);

        Map(m => m.Films);
        Map(m => m.Species);
        Map(m => m.Starships);
        Map(m => m.Vehicles);

        Map(m => m.Url);
        Map(m => m.Created);
        Map(m => m.Edited);
    }
}
