﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2018_4a
{
    class FileReader
    {
        //private List<string> lines;

        public FileReader()
        {
            //this.lines = new List<string>();
        }

        public static List<Record> ReadFile(string path)
        {
            List<Record> records = new List<Record>();
            StreamReader file = new StreamReader(path);
            string line;
            string pattern = @"\[(\d{4}-\d{2}-\d{2}\s\d{2}:\d{2})\]\s(.*)";

            while ((line = file.ReadLine()) != null)
            {
                var regLine = System.Text.RegularExpressions.Regex.Match(line, pattern);

                DateTime timestamp = DateTime.Parse(regLine.Groups[1].Value);
                string message = regLine.Groups[2].Value;
                records.Add(new Record(timestamp, message));
            }

            file.Close();

            return records.OrderBy(r => r.Timestamp).ToList();
        }
    }
}