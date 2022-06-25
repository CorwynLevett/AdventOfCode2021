using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC___2021
{
    public class HelpfulTools
    {
        public static string TheMostCommon(string[] input, int y)
        {
            int zeroCount = 0;
            int oneCount = 0;
            string mostCommmonBit = "";
            for (int i = 0; i < input.Length; i++)
            {
                var span = input[i].AsSpan();
                var value = span[y];
                _ = value == '0' ? zeroCount++ : oneCount++;
                _ = zeroCount > oneCount ? mostCommmonBit = "0" : mostCommmonBit = "1";
            }
            return mostCommmonBit;
        }

        public static string InvertBinary(string binary)
        {
            char[] arr = binary.ToCharArray();
            string invert = "";
            foreach (char digit in arr)
            {
                _ = digit == '1' ? invert += "0" : invert += "1";
            }
            return invert;
        }

        public static List<string> OxygenGenerator(List<string> input, int index)
        {
            var listOfOneNumbers = new List<string>();
            var listOfZeroNumbers = new List<string>();
            for (int i = 0; i < input.Count; i++)
            {
                var span = input[i].AsSpan();
                var value = span[index];
                if (value is '0')
                {
                    listOfZeroNumbers.Add(input[i]);
                }
                else
                {
                    listOfOneNumbers.Add(input[i]);
                }
            }
            if (listOfOneNumbers.Count == listOfZeroNumbers.Count)
            {
                return listOfOneNumbers;
            }
            return listOfOneNumbers.Count > listOfZeroNumbers.Count ? listOfOneNumbers : listOfZeroNumbers;
        }

        public static List<string> C02Scrubber(List<string> input, int index)
        {
            var listOfOneNumbers = new List<string>();
            var listOfZeroNumbers = new List<string>();
            for (int i = 0; i < input.Count; i++)
            {
                var span = input[i].AsSpan();
                var value = span[index];
                if (value is '0')
                {
                    listOfZeroNumbers.Add(input[i]);
                }
                else
                {
                    listOfOneNumbers.Add(input[i]);
                }
            }
            if (listOfOneNumbers.Count == listOfZeroNumbers.Count)
            {
                return listOfZeroNumbers;
            }
            return listOfOneNumbers.Count < listOfZeroNumbers.Count ? listOfOneNumbers : listOfZeroNumbers;
        }

        public static void Looper(int[][] arr, int ball, int iterations)
        {
            foreach (var card in arr)
            {
                int[] cardrow = arr[iterations];
                if (cardrow.Select(num => num).Contains(ball)) //checking current card
                {
                    Console.WriteLine($"MATCH! card number {iterations} has ball {ball}"); //are you checking every card?
                }
                else
                {
                    Console.WriteLine($"card number {iterations} doesn't have ball {ball}");
                }
                iterations++;
            }
        }
    }
}
