using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace API_Test.DataModels;

internal class StarshipDataModel : IDataModel
{
    public string name { get; set; }
    public string model { get; set; }
    public string manufacturer { get; set; }
    public string cost_in_credits { get; set; }
    public string length { get; set; }
    public string max_atmosphering_speed { get; set; }
    public string crew { get; set; }
    public string passengers { get; set; }
    public string cargo_capacity { get; set; }
    public string consumables { get; set; }
    public string hyperdrive_rating { get; set; }
    public string MGLT { get; set; }
    public string starship_class { get; set; }
    public List<string> pilots { get; set; }
    public List<string> films { get; set; }
    public DateTime created { get; set; }
    public DateTime edited { get; set; }
    public string url { get; set; }
    public string ResponseName { get => "starships"; }
    public void Display()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Model: {model}");
        Console.WriteLine($"Manufacturer:  {manufacturer}");
        Console.WriteLine($"Cost in Credits: {cost_in_credits}");
        Console.WriteLine($"Length: {length}");
        Console.WriteLine($"MAX Atmosphering Speed: {max_atmosphering_speed}");
        Console.WriteLine($"Crew: {crew}");
        Console.WriteLine($"Passengers: {passengers}");
        Console.WriteLine($"Cargo Capacity: {cargo_capacity}");
        Console.WriteLine($"Consumables: {consumables}");
        Console.WriteLine($"HyperDrive Rating: {hyperdrive_rating}");
        Console.WriteLine($"MGLT: {MGLT}");
        Console.WriteLine($"Starship Class: {starship_class}");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
    }
}
