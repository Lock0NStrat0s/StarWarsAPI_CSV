using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace API_Test.DataModels;

public class StarshipDataModel : IDataModel
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
    public string Films => (films != null && films.Any()) ? string.Join("; ", films.Select(a => a)) : string.Empty;
    public string Pilots => (pilots != null && pilots.Any()) ? string.Join("; ", pilots.Select(a => a)) : string.Empty;
}

public class StarshipDataModelMap : ClassMap<StarshipDataModel>
{
    public StarshipDataModelMap()
    {
        Map(m => m.name);
        Map(m => m.model);
        Map(m => m.manufacturer);
        Map(m => m.cost_in_credits);
        Map(m => m.length);
        Map(m => m.max_atmosphering_speed);
        Map(m => m.crew);
        Map(m => m.cargo_capacity);
        Map(m => m.passengers);
        Map(m => m.consumables);
        Map(m => m.hyperdrive_rating);
        Map(m => m.MGLT);
        Map(m => m.starship_class);

        Map(m => m.Films);
        Map(m => m.Pilots);

        Map(m => m.url);
        Map(m => m.created);
        Map(m => m.edited);
    }
}
