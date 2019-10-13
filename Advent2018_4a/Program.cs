using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2018_4a
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Record> records = FileReader.ReadFile("../../input.txt");

            GuardController gc = new GuardController();
            gc.AnalyzeRecords(records);
            gc.MostAsleepGuard();
            gc.MostFavoriteMinute();

            Console.WriteLine("Completed. Press a key...");
            Console.ReadKey();

        }
    }
}
