using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC___2021
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Day 1 Answers *****");
            Console.WriteLine("Part 1 is: " + Day1Part1());
            Console.WriteLine("Part 2 is: " + Day1Part2());
            Console.WriteLine();
            Console.WriteLine("***** Day 2 Answers *****");
            Console.WriteLine("Part 1 is: " + Day2Part1());
            Console.WriteLine("Part 2 is: " + Day2Part2());
            Console.WriteLine();
            Console.WriteLine("***** Day 3 Answers *****");
            Console.WriteLine("Part 1 is: " + Day3_Part1());
            Console.WriteLine("Part 2 is: " + Day3_Part2());
            Console.WriteLine();

        }

        public static int Day1Part1()
        {
            var input = File.ReadAllLines(@"C:\AOC\Day1Input.txt");
            int increaseDetected = 0;
            int lastSonar = int.Parse(input[0]);
            for (int i = 1; i < input.Length; i++)
            {
                int currentSonar = int.Parse(input[i]);
                if (currentSonar > lastSonar)
                {
                    increaseDetected++;
                }
                lastSonar = currentSonar;
            }
            return increaseDetected;
        }

        public static int Day1Part2()
        {
            var input = File.ReadAllLines(@"C:\AOC\Day1Input.txt");
            Queue<int> queue = new Queue<int>();
            int increaseDetected = 0;
            queue.Enqueue(int.Parse(input[0]));
            queue.Enqueue(int.Parse(input[1]));
            queue.Enqueue(int.Parse(input[2]));
            for (int i = 3; i < input.Length; i++)
            {
                int addtionToWindow = int.Parse(input[i]);
                int removalFromWindow = queue.Dequeue();
                if (addtionToWindow > removalFromWindow)
                {
                    increaseDetected++;
                }
                queue.Enqueue(addtionToWindow);
            }
            return increaseDetected;
        }

        public static int Day2Part1()
        {
            var input = File.ReadAllLines(@"C:\AOC\Day2Input.txt");
            int horizonalPosition = 0;
            int depthPosition = 0;
            foreach (string i in input)
            {
                if (i.Contains("forward "))
                {
                    string[] x = i.Split(" ");
                    int.TryParse(x[1], out int value);
                    horizonalPosition += value;
                }
                else if (i.Contains("down "))
                {
                    string[] x = i.Split(" ");
                    int.TryParse(x[1], out int value);
                    depthPosition += value;
                }
                else if (i.Contains("up "))
                {
                    string[] x = i.Split(" ");
                    int.TryParse(x[1], out int value);
                    depthPosition -= value;
                }
            }
            int answer = horizonalPosition * depthPosition;
            return answer;
        }

        public static int Day2Part2()
        {
            var input = File.ReadAllLines(@"C:\AOC\Day2Input.txt");
            int horizonalPosition = 0;
            int depthPosition = 0;
            int aim = 0;
            foreach (string direction in input)
            {
                if (direction.Contains("forward "))
                {
                    string[] directionValue = direction.Split(" ");
                    int.TryParse(directionValue[1], out int value);
                    horizonalPosition += value;
                    depthPosition = value * aim + depthPosition;
                }
                else if (direction.Contains("down "))
                {
                    string[] directionValue = direction.Split(" ");
                    int.TryParse(directionValue[1], out int value);
                    aim += value;
                }
                else if (direction.Contains("up "))
                {
                    string[] directionValue = direction.Split(" ");
                    int.TryParse(directionValue[1], out int value);
                    aim -= value;
                }
            }
            int answer = horizonalPosition * depthPosition;
            return answer;
        }

        public static decimal Day3_Part1()
        {
            var input = File.ReadAllLines(@"C:\AOC\Day3Input.txt");
            string commonBinaryReading = "";
            for (int i = 0; i < 12; i++)
            {
                var digits = HelpfulTools.TheMostCommon(input, i, 1);
                commonBinaryReading += digits;
            }
            var gammaRate = Convert.ToInt32(commonBinaryReading, 2);
            string uncommonBinaryReading = HelpfulTools.InvertBinary(commonBinaryReading);
            decimal epsilonRate = Convert.ToInt32(uncommonBinaryReading, 2);
            decimal answer = gammaRate * epsilonRate;
            return answer;
        }

        public static decimal Day3_Part2()
        {
            var input = File.ReadAllLines(@"C:\AOC\Day3Input.txt").ToList();
            var refinementOX = HelpfulTools.OxygenGenerator(input, 0);
            var refinementC02 = HelpfulTools.C02Scrubber(input, 0);
            for (int i = 1; i < 12; i++)
            {
                if (refinementOX.Count > 1)
                {
                    refinementOX = HelpfulTools.OxygenGenerator(refinementOX, i);
                }
                if (refinementC02.Count > 1)
                {
                    refinementC02 = HelpfulTools.C02Scrubber(refinementC02, i);
                }
            }
            decimal oxygen = Convert.ToInt32(refinementOX[0], 2);
            decimal c02 = Convert.ToInt32(refinementC02[0], 2);
            decimal answer = oxygen * c02;
            return answer;
        }
    }
}