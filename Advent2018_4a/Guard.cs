using System;
using System.Linq;

namespace Advent2018_4a
{
    class Guard
    {
        public int Id { get; set; }
        public int MinutesAsleep { get; set; }
        public int[] FavoriteMinute { get; set; }

        public Guard(int id)
        {
            Id = id;
            MinutesAsleep = 0;
            FavoriteMinute = new int[60];
        }

        public int GetMostFavoriteMinuteIndex()
        {
            return Array.IndexOf(FavoriteMinute, FavoriteMinute.Max());
        }

        public int GetMostFavoriteMinuteValue()
        {
            return FavoriteMinute.Max();
        }
    }
}
