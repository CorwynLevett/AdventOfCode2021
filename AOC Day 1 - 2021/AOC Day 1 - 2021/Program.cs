using System;
using System.Collections.Generic;
using System.IO;

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
                if (i.Contains("down "))
                {
                    string[] x = i.Split(" ");
                    int.TryParse(x[1], out int value);
                    depthPosition += value;
                }
                if (i.Contains("up "))
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
                if (direction.Contains("down "))
                {
                    string[] directionValue = direction.Split(" ");
                    int.TryParse(directionValue[1], out int value);
                    aim += value;
                }
                if (direction.Contains("up "))
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
            var firstnumber = CharChecker.WhatsTheMostCommon(input, 0, 1);
            var secondnumber = CharChecker.WhatsTheMostCommon(input, 1, 1);
            var thirdnumber = CharChecker.WhatsTheMostCommon(input, 2, 1);
            var fourthnumber = CharChecker.WhatsTheMostCommon(input, 3, 1);
            var fifthnumber = CharChecker.WhatsTheMostCommon(input, 4, 1);
            var sixthNumber = CharChecker.WhatsTheMostCommon(input, 5, 1);
            var seventhNumber = CharChecker.WhatsTheMostCommon(input, 6, 1);
            var eighthNumber = CharChecker.WhatsTheMostCommon(input, 7, 1);
            var ninthNumber = CharChecker.WhatsTheMostCommon(input, 8, 1);
            var tenthNumber = CharChecker.WhatsTheMostCommon(input, 9, 1);
            var eleventhNumber = CharChecker.WhatsTheMostCommon(input, 10, 1);
            var twelthNumber = CharChecker.WhatsTheMostCommon(input, 11, 1);

            string commonBinaryReading = $"{firstnumber}{secondnumber}{thirdnumber}{fourthnumber}{fifthnumber}{sixthNumber}{seventhNumber}" +
                $"{eighthNumber}{ninthNumber}{tenthNumber}{eleventhNumber}{twelthNumber}";
            var gammaRate = Convert.ToInt32(commonBinaryReading, 2);

            string uncommonBinaryReading = CharChecker.InvertBinary(commonBinaryReading);
            decimal epsilonRate = Convert.ToInt32(uncommonBinaryReading, 2);

            decimal answer = gammaRate * epsilonRate;

            return answer;
        }

        public static int Day3_Part2()
        {
            var input = File.ReadAllLines(@"C:\AOC\Day3Input.txt");


            int answer = 0;
            return answer;
        }
    }
}