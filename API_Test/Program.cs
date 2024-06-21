using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Reflection;
using API_Test.DataModels;
using System.Net;

namespace API_Test;

internal class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true;
        do
        {
            Console.Clear();
            Console.Write("Welcome to the Star Wars Database!\n\nOptions:\n1: People\n2: Planets\n3: Starships\n4: Films\n5: Species\n6: Vehicles\n\nYour selection: ");

            IDataModel dataModel = null;
            try
            {
                dataModel = DataModelFactory.GetDataModelType(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
;

            if (dataModel != null)
            {
                Console.Write($"Enter the ID of the {dataModel.ResponseName} you want to see: ");
                string id = Console.ReadLine();
                if (!String.IsNullOrEmpty(id))
                {
                    try
                    {
                        GetInfo(id, dataModel).Wait();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                else
                {
                    isRunning = false;
                }
            }
            else
            {
                isRunning = false;
            }

            Console.ReadKey();
        } while (isRunning);
    }
    static async Task GetInfo(string id, IDataModel dataModel)
    {
        var endpoint = $"https://swapi.dev/api/{dataModel.ResponseName}/{id}/";
        var data = await FetchDataFromAPI(endpoint);
        var record = DataModelFactory.GetModelInfo(data, dataModel);

        record.Display();
    }
    static async Task<string> FetchDataFromAPI(string url)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetStringAsync(url);
            return response;
        }
    }

    //static void WriteDataToCSV<T>(List<T> records, string filePath)
    //{
    //    using (var writer = new StreamWriter(filePath))
    //    using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
    //    {
    //        csv.WriteRecords(records);
    //    }
    //}
    //static string GetFileNameFromEndpoint(string endpoint)
    //{
    //    var uri = new Uri(endpoint);
    //    return uri.Segments[uri.Segments.Length - 1];
    //}
}