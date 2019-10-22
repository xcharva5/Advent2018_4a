using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2018_4a
{
    class GuardController
    {
        private List<Guard> guards = new List<Guard>();

        public void AnalyzeRecords(List<Record> records)
        {
            Regex startsShift = new Regex(@".*#(\d{3,4})\s.*");
            Regex wakesUp = new Regex(@".*(wakes up)");
            Regex fallsAsleep = new Regex(@".*(falls asleep)");

            int guardId = -1;
            int fellAsleep = -1;
            int wokeUp = -1;

            foreach (Record rec in records)
            {
                if (startsShift.IsMatch(rec.Message))
                {
                    guardId = int.Parse(Regex.Match(rec.Message, startsShift.ToString()).Groups[1].Value);

                    if (!guards.Any(g => g.Id == guardId))
                    {
                        guards.Add(new Guard(guardId));
                    }
                }
                else if (fallsAsleep.IsMatch(rec.Message))
                {
                    fellAsleep = rec.Timestamp.Minute;
                }
                else if (wakesUp.IsMatch(rec.Message))
                {
                    wokeUp = rec.Timestamp.Minute;

                    int IdToChange = guards.FindIndex(g => g.Id == guardId);
                    if (IdToChange >= 0)
                    {
                        guards[IdToChange].MinutesAsleep += (wokeUp - fellAsleep);
                    }

                    for (int min = fellAsleep; min < wokeUp; min++)
                    {
                        guards[IdToChange].FavoriteMinute[min]++;
                    }
                }
                else
                {
                    Console.WriteLine("Unrecognized action");
                }
            }
        }

        public void MostAsleepGuard()
        {
            guards = guards.OrderByDescending(g => g.MinutesAsleep).ToList();

            Console.WriteLine(String.Format("============================="));
            Console.WriteLine(String.Format("|      TOP DREAMERS         |"));
            Console.WriteLine(String.Format("============================="));
            Console.WriteLine(String.Format("         | Minutes | Favorite"));
            Console.WriteLine(String.Format("Guard ID | Slept   | Minute  "));
            Console.WriteLine(String.Format("============================="));

            foreach (Guard g in guards)
            {                
                Console.WriteLine(String.Format("#{0,-8}|{1,9}|{2,9}", g.Id, g.MinutesAsleep, g.GetMostFavoriteMinuteIndex()));
            }

            Console.WriteLine(String.Format("============================="));
            Console.ReadKey();
        }

        public void MostFavoriteMinute()
        {
            int topMinuteOverall = -1;
            int topMinuteValue = -1;
            int guardId = -1;

            foreach(Guard g in guards)
            {
                int topMinute = g.GetMostFavoriteMinuteIndex();

                if (g.GetMostFavoriteMinuteValue() > topMinuteValue)
                {
                    topMinuteOverall = topMinute;
                    topMinuteValue = g.GetMostFavoriteMinuteValue();
                    guardId = g.Id;
                }
            }

            Console.WriteLine(String.Format("============================="));
            Console.WriteLine(String.Format("|   MOST FAVORITE MINUTE    |"));
            Console.WriteLine(String.Format("============================="));
            Console.WriteLine("Guard #{0}", guardId);
            Console.WriteLine("Slept {0} times at minute {1}.", topMinuteValue, topMinuteOverall);
            Console.ReadKey();
        }
    }
}
