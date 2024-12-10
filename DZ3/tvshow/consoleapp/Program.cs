using logic;
using System.Reflection;

namespace consoleapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Assume that the number of rows in the text file is always at least 10. 
            // Assume a valid input file.
            string fileName = "shows.tv";
            string outputFileName = "storage.tv";

            IPrinter printer = new ConsolePrinter();
            printer.Print($"Reading data from file {fileName}");

            Episode[] episodes = TvUtilities.LoadEpisodesFromFile(fileName);
            Season season = new Season(1, episodes);

            printer.Print($"Good season? Total viewers: {season.GetTotalViewers()}");
            printer.Print($"Watch whole season? Ends at: {season.GetBingeEnd()}");

            printer.Print(season.ToString());
            for (int i = 0; i < season.Length; i++)
            {
                season[i].AddView(TvUtilities.GenerateRandomScore());
            }
            printer.Print(season.ToString());

            printer = new FilePrinter(outputFileName);
            printer.Print(season.ToString());
        }
    }
}