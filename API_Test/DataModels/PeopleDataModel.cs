using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
    [JsonProperty("films")]
    public List<string> Films { get; set; }
    [JsonProperty("species")]
    public List<string> Species { get; set; }
    [JsonProperty("starships")]
    public List<string> Starships { get; set; }
    [JsonProperty("vehicles")]
    public List<string> Vehicles { get; set; }
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
}