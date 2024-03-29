﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2018_4a
{
    class FileReader
    {
        // parses each line of an input file by a pattern and stores it to Record object
        // returns a List of Records ordered by Timestamp
        public static List<Record> ReadFile(string path)
        {
            string line;
            Regex pattern = new Regex(@"\[(\d{4}-\d{2}-\d{2}\s\d{2}:\d{2})\]\s(.*)");
            List<Record> records = new List<Record>();
            StreamReader file = new StreamReader(path);            

            while ((line = file.ReadLine()) != null)
            {
                Match regLine = pattern.Match(line);

                DateTime timestamp = DateTime.Parse(regLine.Groups[1].Value);
                string message = regLine.Groups[2].Value;

                records.Add(new Record(timestamp, message));
            }

            file.Close();

            return records.OrderBy(r => r.Timestamp).ToList();
        }
    }
}
