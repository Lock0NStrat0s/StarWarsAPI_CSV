using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace API_Test.DataModels;

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
    public string ResponseName { get => "species"; }
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
}
