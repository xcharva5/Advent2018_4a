using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent2018_4a
{
    class GuardController
    {
        private List<Guard> guards = new List<Guard>();

        public void MostAsleepGuard(List<Record> records)
        {
            Regex startsShift = new Regex(@".*#(\d{3,4})\s.*");
            Regex wakesUp = new Regex(@".*(wakes up)");
            Regex fallsAsleep = new Regex(@".*(falls asleep)");

            //Guard pickedGuard = null;
            int guardId = -1;
            int fellAsleep = -1;
            int wokeUp = -1;

            foreach (Record rec in records)
            {
                if (startsShift.IsMatch(rec.Message))
                {
                    guardId = Int32.Parse(Regex.Match(rec.Message, startsShift.ToString()).Groups[1].Value);

                    if (!guards.Any(g => g.Id == guardId))
                    {
                        guards.Add(new Guard(guardId, 0, -1));
                        Console.WriteLine("Guard #{0} added.", guardId);
                    }
                    else
                    {
                        // guard already exist
                    }
                } else if (fallsAsleep.IsMatch(rec.Message))
                {
                    // the guard falls asleep 
                    fellAsleep = rec.Timestamp.Minute;
                    Console.WriteLine("sleep: " + wokeUp);
                }
                else if(wakesUp.IsMatch(rec.Message))
                {
                    // the guard wakes up  
                    wokeUp = rec.Timestamp.Minute;
                    Console.WriteLine("weak up: " + wokeUp);
                }
                else
                {
                    Console.WriteLine("Unrecognized action");
                }
            }

            foreach (Guard g in guards)
            {
                Console.WriteLine("{0} -- {1} // {2}", g.Id, g.MinutesAsleep, g.FavoriteMinute);

            }

        }
    }
}
