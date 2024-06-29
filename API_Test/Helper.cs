using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Formats.Asn1;

namespace API_Test;

public static class Helper
{
    public static string GetResponse(string text)
    {
        Console.Clear();
        Console.Write(text);
        return Console.ReadLine();
    }

    public static void WriteDataToCSV<T>(List<T> records, string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            csv.WriteRecords(records);
        }
    }
}