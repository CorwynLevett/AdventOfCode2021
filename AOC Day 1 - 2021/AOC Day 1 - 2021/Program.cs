using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AOC_Day_1___2021
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Day1Part1());
            Console.WriteLine(Day1Part2());
        }

        public static int Day1Part1()
        {
            var input = File.ReadAllLines(@"C:\AOC\Day1Input.txt");
            int increaseDetected = 0;
            int currentSonar = 0;
            int lastSonar;
            foreach (string line in input)
            {
                lastSonar = currentSonar;
                currentSonar = int.Parse(line);
                if (lastSonar > 1)
                {
                    if (currentSonar > lastSonar)
                    {
                        increaseDetected++;
                    }
                }
            }
            return increaseDetected;
        }

        public static int Day1Part2()
        {
            var input = System.IO.File.ReadAllLines(@"C:\AOC\Day1Input.txt");
            var sonarReadings = new List<int>();
            var groupedResults = new List<int>();
            int increaseDetected = 0;
            foreach (var item in input)
            {
                sonarReadings.Add(int.Parse(item));
                if (sonarReadings.Count >= 3)
                {
                    int result = sonarReadings.ElementAt(sonarReadings.Count - 3) + sonarReadings.ElementAt(sonarReadings.Count - 2) + sonarReadings.ElementAt(sonarReadings.Count - 1);
                    groupedResults.Add(result);
                    if (groupedResults.Count > 1)
                    {
                        if (groupedResults.ElementAt(groupedResults.Count - 2) < groupedResults.ElementAt(groupedResults.Count - 1))
                        {
                            increaseDetected++;
                        }
                    }
                }
            }
            return increaseDetected;
        }
    }
}
