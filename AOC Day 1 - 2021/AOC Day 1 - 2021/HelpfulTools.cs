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



        public static BingoBoard CardBuilder(int count, int cardId)
        {
            var arr = new int[5][];
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
            return new BingoBoard(arr, cardId);
        }

        public static int CheckForWinner(List<BingoCardModel> winnerslist)
        {
            int cardIndex = 0; 
            int rowIndex = 0;
            int colIndex = 0;

            var CardAndRowWins = winnerslist.OrderBy(x => x.CardId).ToList();
            foreach (var card in CardAndRowWins)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (card.CardId != cardIndex)
                    {
                        cardIndex = card.CardId;
                    }
                    if (card.Row != rowIndex)
                    {
                        rowIndex++;
                    }
                    if (card.Column != colIndex)
                    {
                        colIndex++;
                    }
                }
                int numWinsOnCard = CardAndRowWins.Count(where => where.CardId == cardIndex);
                int numWinsOnRow = CardAndRowWins.Count(where => where.CardId == cardIndex && where.Row == rowIndex);
                int numWinsOnCol = CardAndRowWins.Count(where => where.CardId == cardIndex && where.Column == colIndex);
                if (numWinsOnCard > 5 && numWinsOnRow == 5) //not sure this is fully reliable 
                {
                    return cardIndex;
                }
                else if (numWinsOnCard > 5 && numWinsOnCol == 5)
                {
                    return cardIndex;
                }
                cardIndex = 0;
                colIndex = 0;
                rowIndex = 0;
            }
            return -1;
        }

        public static List<int> CheckForWinnerALL(List<BingoCardModel> winnerslist)
        {
            int cardIndex = 0;
            int rowIndex = 0;
            int colIndex = 0;

            List<int> values = new List<int>();

            var CardAndRowWins = winnerslist.OrderBy(x => x.CardId).ToList();
            foreach (var card in CardAndRowWins)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (card.CardId != cardIndex)
                    {
                        cardIndex = card.CardId;
                    }
                    if (card.Row != rowIndex)
                    {
                        rowIndex++;
                    }
                    if (card.Column != colIndex)
                    {
                        colIndex++;
                    }
                }
                int numWinsOnCard = CardAndRowWins.Count(where => where.CardId == cardIndex);
                int numWinsOnRow = CardAndRowWins.Count(where => where.CardId == cardIndex && where.Row == rowIndex);
                int numWinsOnCol = CardAndRowWins.Count(where => where.CardId == cardIndex && where.Column == colIndex);
                if (numWinsOnCard > 5 && numWinsOnRow == 5) //not sure this is fully reliable 
                {
                    if (!values.Any(x => x.Equals(cardIndex)))
                    {
                        values.Add(cardIndex);
                    }
                }
                else if (numWinsOnCard > 5 && numWinsOnCol == 5)
                {
                    if (!values.Any(x => x.Equals(cardIndex)))
                    {
                        values.Add(cardIndex);
                    }
                }
                cardIndex = 0;
                colIndex = 0;
                rowIndex = 0;
            }
            return values;
        }

    }
}
