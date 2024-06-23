using API_Test.DataModels;
using API_Test.FullResponseDataModels;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

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
            }
            else
            {
                if (userInput == "1")
                {
                    var urlParameter = CreateFullDataModel(GetUserInputSelectEndpoint());
                    if (urlParameter == null)
                    {
                        isRunning = false;
                    }
                    else
                    {
                        CallFullModelAPI(urlParameter);
                    }
                }
                else
                {
                    IDataModel singleDataModel = CreateSingleDataModel(GetUserInputSelectEndpoint());
                    if (singleDataModel == null)
                    {
                        isRunning = false;
                    }
                    else
                    {
                        CallSingleModelAPI(singleDataModel);
                    }
                }
            }
            Console.Write("\nPress any key to continue: ");
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
    private static string CreateFullDataModel(string response)
    {
        try
        {
            return DataModelFactory.GetFullDataModelType(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return null;
    }

    private static IDataModel CreateSingleDataModel(string response)
    {
        try
        {
            return DataModelFactory.GetSingleDataModelType(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return null;
    }
    #endregion

    #region CALL API
    public static void CallFullModelAPI(string param)
    {
        try
        {
            GetFullModelInfo(param).Wait();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void CallSingleModelAPI(IDataModel singleDataModel)
    {
        Console.Write($"Enter the ID of the \"{singleDataModel.ResponseName}\" to display: ");
        string id = Console.ReadLine();

        if (!String.IsNullOrEmpty(id))
        {
            try
            {
                GetSingleModelInfo(id, singleDataModel).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    #endregion

    #region GET INFO FROM DB
    static async Task GetFullModelInfo(string param)
    {
        var endpoint = $"https://swapi.dev/api/{param}/";
        var data = "";
        try
        {
            data = await FetchDataFromAPI(endpoint);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        var records = DataModelFactory.GetFullDeserializedModel(data, param);

        try
        {
            records.PrintResults();
            records.ReturnResponseName();           
            //WriteDataToCSV(records, "C:\\Users\\moham\\OneDrive\\Desktop\\API.csv");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static async Task GetSingleModelInfo(string id, IDataModel singleDataModel)
    {
        var endpoint = $"https://swapi.dev/api/{singleDataModel.ResponseName}/{id}/";
        var data = "";
        try
        {
            data = await FetchDataFromAPI(endpoint);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        var record = DataModelFactory.GetSingleDeserializedModel(data, singleDataModel);

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