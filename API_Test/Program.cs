using API_Test.ApplicationManager;

namespace API_Test;

public class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true;
        do
        {
            isRunning = Application.RunApplication(isRunning);

            Console.Write("\nPress any key to continue: ");
            Console.ReadKey();
        } while (isRunning);
    }
}