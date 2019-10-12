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
            gc.MostAsleepGuard(records);

            /*foreach (var record in records)
            {
                Console.WriteLine(record.Timestamp + "  " + record.Message);
            }*/

            Console.WriteLine("Completed. Press a key...");
            Console.ReadKey();

        }
    }
}
