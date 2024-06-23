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
            isRunning = RunApplication(isRunning);
            Console.Write("\nPress any key to continue: ");
            Console.ReadKey();

        } while (isRunning);
    }

    #region RUN APPLICATION
    private static bool RunApplication(bool isRunning)
    {
        string userInput = GetUserInputFullOrSingleResponse();
        if (userInput != "1" && userInput != "2")
        {
            isRunning = false;
        }
        else
        {
            var urlParameter = GetUserEndpoint(GetUserInputSelectEndpoint());
            if (urlParameter == null)
            {
                isRunning = false;
            }
            else
            {
                if (userInput == "1")
                {
                    CallFullModelAPI(urlParameter);
                }
                else
                {
                    CallSingleModelAPI(urlParameter);
                }
            }
        }

        return isRunning;
    }
    #endregion

    #region GET USER INPUT
    private static string GetUserInputFullOrSingleResponse()
    {
        Console.Clear();
        Console.Write("Welcome to the Star Wars Database! (utilizing SWAPI)\n\nOptions:\n1: FULL RESPONSE (data records will be stored in a csv file)\n2: SINGLE RESPONSE (data records will be displayed on console with nice fancy colours)\nAny other key to EXIT\n\nYour Selection: ");

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
    private static string GetUserEndpoint(string response)
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

    public static void CallSingleModelAPI(string param)
    {
        Console.Write($"Enter the ID of the \"{param.ToUpper()}\" to display: ");
        string id = Console.ReadLine();

        if (!String.IsNullOrEmpty(id))
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
            records.RecordResults();
            //WriteDataToCSV(records, "C:\\Users\\moham\\OneDrive\\Desktop\\API.csv");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
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