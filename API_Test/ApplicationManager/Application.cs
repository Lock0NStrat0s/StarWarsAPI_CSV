using API_Test.FullResponseDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Test.ApplicationManager;

public static class Application
{
    static int pageCount = 1;
    #region RUN APPLICATION
    public static bool RunApplication()
    {
        string userInput = Helper.GetResponse("Welcome to the Star Wars Database! (utilizing SWAPI)\n\nOptions:\n1: FULL RESPONSE (data records will be stored in a csv file)\n2: SINGLE RESPONSE (data records will be displayed on console with nice fancy colours)\nAny other key to EXIT\n\nYour Selection: ");

        return GetFullOrSingleResponse(userInput);
    }

    private static bool GetFullOrSingleResponse(string userInput)
    {
        if (userInput != "1" && userInput != "2")
        {
            return false;
        }
        else
        {
            return GetEndpoint(userInput);
        }
    }

    private static bool GetEndpoint(string userInput)
    {
        var urlParameter = CreateDataModelFromEndpoint(Helper.GetResponse("Welcome to the Star Wars Database! (utilizing SWAPI)\n\nOptions:\n1: People\n2: Planets\n3: Starships\n4: Films\n5: Species\n6: Vehicles\nAny other key to EXIT\n\nYour selection: "));
        if (urlParameter == null)
        {
            return false;
        }
        else
        {
            if (userInput == "1")
            {
                CallFullModelAPI(urlParameter).Wait();
            }
            else
            {
                CallSingleModelAPI(urlParameter);
            }
        }

        return true;
    }
    #endregion

    #region CREATE DATA MODEL
    private static string CreateDataModelFromEndpoint(string response)
    {
        try
        {
            return DataModelFactory.GetDataModelType(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return null;
    }
    #endregion

    #region CALL API
    private static async Task CallFullModelAPI(string param)
    {
        bool isNextNull = false;
        do
        {
            isNextNull = await GatherRecord(param);
        } while (!isNextNull);

    }

    private static async Task<bool> GatherRecord(string param)
    {
        string data = await GetDataFromModel(param);

        var records = DataModelFactory.GetFullDeserializedModel(data, param);

        return AddRecordIfNextPageExists(records);
    }

    private static bool AddRecordIfNextPageExists(IFullDataModel records)
    {
        if (records.next == null)
        {
            return true;
        }
        else
        {
            pageCount++;                            // Increase page count
            AddRecord(false, records);
            return false;
        }
    }

    private static void AddRecord(bool isNextNull, IFullDataModel records)
    {
        try
        {
            records.RecordResults(isNextNull);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static async Task<string> GetDataFromModel(string param)
    {
        var data = "";
        try
        {
            data = await GetFullModelInfo(param);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return data;
    }

    private static void CallSingleModelAPI(string param)
    {
        Console.Write($"Enter the ID of the \"{param.ToUpper()}\" to display: ");
        string id = Console.ReadLine();

        if (!string.IsNullOrEmpty(id))
        {
            try
            {
                GetSingleModelInfo(param, id).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    #endregion

    #region GET INFO FROM API
    static async Task<string> GetFullModelInfo(string param)
    {
        var endpoint = $"https://swapi.dev/api/{param}/?page={pageCount}";
        try
        {
            return await FetchDataFromAPI(endpoint);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return null;
    }

    static async Task GetSingleModelInfo(string param, string id)
    {
        var endpoint = $"https://swapi.dev/api/{param}/{id}/";
        var data = "";
        try
        {
            data = await FetchDataFromAPI(endpoint);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        var record = DataModelFactory.GetSingleDeserializedModel(data, param);

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
}
