using API_Test.ApplicationManager;

namespace API_Test;

public class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true; // Flag to keep the application running
        do
        {
            // Run the application
            isRunning = Application.RunApplication();

            Console.Write("\nPress any key to continue: ");
            Console.ReadKey();
        } while (isRunning);
    }
}