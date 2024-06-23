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
            string userInput = GetUserInputFullOrSingleResponse();

            if (userInput != "1" && userInput != "2")
            {
                isRunning = false;
                break;
            }
            else
            {
                IDataModel dataModel = null;
                if (userInput == "1")
                {
                    dataModel = CreateFullDataModel(GetUserInputSelectEndpoint());
                    if (dataModel != null)
                    {
                        CallFullModelAPI(dataModel);
                    }    
                }
                else
                {
                    dataModel = CreateSingleDataModel(GetUserInputSelectEndpoint());
                    if (dataModel != null)
                    {
                        CallSingleModelAPI(dataModel);
                    }
                }

                if (dataModel == null)
                {
                    isRunning = false;
                    break;
                }
            }
            Console.Write("Press any key to continue: ");
            Console.ReadKey();

        } while (isRunning);
    }

    #region GET USER INPUT
    private static string GetUserInputFullOrSingleResponse()
    {
        Console.Clear();
        Console.Write("Welcome to the Star Wars Database! (utilizing SWAPI)\n\nOptions:\n1: Full Response\n2: Single Response\nAny other key to EXIT\n\nYour Selection: ");

        return Console.ReadLine();
    }

    private static string GetUserInputSelectEndpoint()
    {
        Console.Clear();
        Console.Write("Welcome to the Star Wars Database! (utilizing SWAPI)\n\nOptions:\n1: People\n2: Planets\n3: Starships\n4: Films\n5: Species\n6: Vehicles\nAny other key to EXIT\n\nYour selection: ");

        return Console.ReadLine();
    }
    #endregion

    #region CREATE DATA MODEL
    private static IDataModel CreateFullDataModel(string response)
    {
        IDataModel dataModel = null;
        try
        {
            dataModel = DataModelFactory.GetFullDataModelType<>(response);  //ERROR
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return dataModel;
    }

    private static IDataModel CreateSingleDataModel(string response)
    {
        IDataModel dataModel = null;
        try
        {
            dataModel = DataModelFactory.GetSingleDataModelType(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return dataModel;
    }
    #endregion

    #region CALL API
    public static void CallFullModelAPI(IDataModel dataModel)
    {
        try
        {
            GetFullModelInfo(dataModel).Wait();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void CallSingleModelAPI(IDataModel dataModel)
    {
        Console.Write($"Enter the ID of the \"{dataModel.ResponseName}\" to display: ");
        string id = Console.ReadLine();

        if (!String.IsNullOrEmpty(id))
        {
            try
            {
                GetSingleModelInfo(id, dataModel).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    #endregion

    #region GET INFO FROM DB
    static async Task GetFullModelInfo(IDataModel dataModel)
    {
        var endpoint = $"https://swapi.dev/api/{dataModel.ResponseName}/";
        var data = await FetchDataFromAPI(endpoint); //try catch
        var records = DataModelFactory.GetFullDeserializedModel</*need type here*/>(data, dataModel);   //ERROR

        try
        {
            //Console.WriteLine(records);
            //WriteDataToCSV(records, "C:\\Users\\moham\\OneDrive\\Desktop\\API.csv");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static async Task GetSingleModelInfo(string id, IDataModel dataModel)
    {
        var endpoint = $"https://swapi.dev/api/{dataModel.ResponseName}/{id}/";
        var data = await FetchDataFromAPI(endpoint); //try catch
        var record = DataModelFactory.GetSingleDeserializedModel(data, dataModel);

        record.Display();
    }
    #endregion

    static async Task<string> FetchDataFromAPI(string url)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetStringAsync(url);
            return response;
        }
    }

    static void WriteDataToCSV<T>(List<T> records, string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            csv.WriteRecord(records);
        }
    }
    //static string GetFileNameFromEndpoint(string endpoint)
    //{
    //    var uri = new Uri(endpoint);
    //    return uri.Segments[uri.Segments.Length - 1];
    //}
}