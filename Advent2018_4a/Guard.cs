﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2018_4a
{
    class Guard
    {
        public int Id { get; set; }
        public int MinutesAsleep { get; set; }
        public int[] FavoriteMinute { get; set; }

        public Guard(int id, int minutesAsleep, int favoriteMinute)
        {
            Id = id;
            MinutesAsleep = 0;
            FavoriteMinute = new int[60];
        }
    }
}