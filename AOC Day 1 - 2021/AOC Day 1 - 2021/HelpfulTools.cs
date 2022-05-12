using System;
using System.Collections.Generic;

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

        public static List<string> OxygenGenerator(List<string> input, int y)
        {
            int zeroCount = 0;
            int oneCount = 0;
            var listOfOneNumbers = new List<string>();
            var listOfZeroNumbers = new List<string>();
            var finalListToUse = new List<string>();
            for (int i = 0; i < input.Count; i++)
            {
                var span = input[i].AsSpan();
                var value = span[y];

                if (value is '0')
                {
                    zeroCount++;
                    listOfZeroNumbers.Add(input[i]);
                }
                else
                {
                    oneCount++;
                    listOfOneNumbers.Add(input[i]);
                }
            }
            if (oneCount > zeroCount)
            {
                finalListToUse = listOfOneNumbers;
            }
            else if (zeroCount > oneCount)
            {
                finalListToUse = listOfZeroNumbers;
            }
            else if (zeroCount == oneCount)
            {
                finalListToUse = listOfOneNumbers;
            }
            return finalListToUse;
        }

        public static List<string> C02Scrubber(List<string> input, int y)
        {
            int zeroCount = 0;
            int oneCount = 0;
            var listOfOneNumbers = new List<string>();
            var listOfZeroNumbers = new List<string>();
            var finalListToUse = new List<string>();
            for (int i = 0; i < input.Count; i++)
            {
                var span = input[i].AsSpan();
                var value = span[y];
                if (value is '0')
                {
                    zeroCount++;
                    listOfZeroNumbers.Add(input[i]);
                }
                else
                {
                    oneCount++;
                    listOfOneNumbers.Add(input[i]);
                }
            }

            if (oneCount < zeroCount)
            {
                finalListToUse = listOfOneNumbers;
            }
            else if (zeroCount < oneCount)
            {
                finalListToUse = listOfZeroNumbers;
            }
            else if (zeroCount == oneCount)
            {
                finalListToUse = listOfZeroNumbers;
            }
            return finalListToUse;
        }
    }
}
