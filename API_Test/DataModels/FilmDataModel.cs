using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
}
