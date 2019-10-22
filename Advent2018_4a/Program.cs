
namespace Advent2018_4a
{
    class Program
    {
        static void Main(string[] args)
        {
            GuardController gc = new GuardController();
            gc.AnalyzeRecords(FileReader.ReadFile("../../input.txt"));
            gc.MostAsleepGuard();
            gc.MostFavoriteMinute();
        }
    }
}
