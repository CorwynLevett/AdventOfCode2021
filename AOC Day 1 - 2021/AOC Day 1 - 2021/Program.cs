using System;
using System.Collections.Generic;
using System.Linq;

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
            var input = System.IO.File.ReadAllLines(@"C:\AOC\Day1Input.txt");
            var SonarReadings = new List<int>();
            int i = -1;
            int j = 0;
            int count = 0;
            foreach (string line in input)
            {
                SonarReadings.Add(int.Parse(line));
                if (j == 0)
                {
                }
                else if (SonarReadings.ElementAt(i) < SonarReadings.ElementAt(j))
                {
                    count++;
                }
                i++;
                j++;
            }
            return count;
        }

        public static int Day1Part2()
        {
            var input = System.IO.File.ReadAllLines(@"C:\AOC\Day1Input.txt");
            var SonarReadings = new List<int>();
            var GroupedResults = new List<int>();
            int i = -1;
            int j = 0;
            int count = 0;
            int timesrun = 0;
            foreach (var item in input)
            {
                SonarReadings.Add(int.Parse(item));
            }
            int a = 0;
            int b = 1;
            int c = 2;
            for (int s = 0; s < SonarReadings.Count; s++)
            {
                timesrun++;
                int result = SonarReadings.ElementAt(a) +
                SonarReadings.ElementAt(b) +
                SonarReadings.ElementAt(c);
                GroupedResults.Add(result);
                //Console.WriteLine($"{ SonarReadings.ElementAt(a)}, {SonarReadings.ElementAt(b)}, {SonarReadings.ElementAt(c)} and total is {result}");
                a++;
                b++;
                c++;
                s++;
            }
                foreach (var item in GroupedResults)
                {
                    if (j == 0)
                    {
                    }
                    else if (GroupedResults.ElementAt(i) < GroupedResults.ElementAt(j))
                    {
                        count++;
                        //Console.WriteLine($"{GroupedResults.ElementAt(i)}");
                        //Console.WriteLine($"{GroupedResults.ElementAt(j)} (Increase) {count}");
                        //if(GroupedResults.ElementAt(i) == GroupedResults.ElementAt(j))
                        //Console.WriteLine($"Equal Detected {GroupedResults.ElementAt(i)} is same as {GroupedResults.ElementAt(j)}");
                    }
                    i++;
                    j++;
                }
            //Console.WriteLine(timesrun);
            return count;
        }
       
    }
}
