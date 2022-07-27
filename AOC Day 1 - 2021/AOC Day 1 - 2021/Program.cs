using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC___2021
{
    public static class Program
    {
        private static IEnumerable<(int, int)> newlist;

        static void Main(string[] args)
        {
            Console.WriteLine("***** Day 1 Answers *****");
            Console.WriteLine("Part 1 is: " + PuzzleDays.Day1Part1());
            Console.WriteLine("Part 2 is: " + PuzzleDays.Day1Part2());
            Console.WriteLine();
            Console.WriteLine("***** Day 2 Answers *****");
            Console.WriteLine("Part 1 is: " + PuzzleDays.Day2Part1());
            Console.WriteLine("Part 2 is: " + PuzzleDays.Day2Part2());
            Console.WriteLine();
            Console.WriteLine("***** Day 3 Answers *****");
            Console.WriteLine("Part 1 is: " + PuzzleDays.Day3_Part1()); // should be 693486
            Console.WriteLine("Part 2 is: " + PuzzleDays.Day3_Part2()); // should be 3379326
            Console.WriteLine();
            Console.WriteLine("***** Day 4 Answers *****");
            Console.WriteLine("Part 1 is: " + PuzzleDays.Day4_Part1()); // should be 2496
            Console.WriteLine("Part 2 is: " + PuzzleDays.Day4_Part2()); // should be 25925
        }

    }
}