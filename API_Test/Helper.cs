using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace API_Test;

// Helper class to provide common methods
public static class Helper
{
    // Clear console and get user response
    public static string GetResponse(string text)
    {
        Console.Clear();
        Console.Write(text);
        return Console.ReadLine();
    }

    // Write data to CSV
    public static void WriteDataToCSV<T>(List<T> records, string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            csv.WriteRecords(records);
        }
    }
}