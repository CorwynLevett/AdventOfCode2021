using System;
using System.Collections.Generic;
using System.IO;
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



        public static Array CardBuilder(int[][] arr, int count)
        {
            arr = new int[5][];
            int y = 0;
            foreach (var line in File.ReadLines(@"C:\AOC\Day4Input.txt").Skip(count))
            {
                int[] lineToAdd = line
                .Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(Int32.Parse).ToArray();
                if (line == "")
                {
                    break;
                }
                else
                {
                    arr[y++] = lineToAdd;
                }
            }
            return arr;
        }

        public static int CheckForWinner(List<Tuple<int, int, int>> winnerslist)
        {
            int cardIndex = 0; 
            int rowIndex = 0;
            int colIndex = 0;

            var CardAndRowWins = winnerslist.OrderBy(t => t).ToList();
            foreach (var card in CardAndRowWins)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (card.Item1 != cardIndex)
                    {
                        cardIndex = card.Item1;
                    }
                    if (card.Item2 != rowIndex)
                    {
                        rowIndex++;
                    }
                    if (card.Item3 != colIndex)
                    {
                        colIndex++;
                    }
                }
                int numWinsOnCard = CardAndRowWins.Count(where => where.Item1 == cardIndex);
                int numWinsOnRow = CardAndRowWins.Count(where => where.Item1 == cardIndex && where.Item2 == rowIndex);
                if (numWinsOnCard > 5 && numWinsOnRow == 5) //not sure this is fully reliable 
                {
                    return cardIndex;
                }
                cardIndex = 0;
                colIndex = 0;
                rowIndex = 0;
            }
            return -1;
        }
    }
}
