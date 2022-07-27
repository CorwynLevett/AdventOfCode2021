using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC___2021
{
    public class PuzzleDays
    {
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
            Queue<int> queue = new();
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
                    _ = int.TryParse(x[1], out int value);
                    horizonalPosition += value;
                }
                else if (i.Contains("down "))
                {
                    string[] x = i.Split(" ");
                    _ = int.TryParse(x[1], out int value);
                    depthPosition += value;
                }
                else if (i.Contains("up "))
                {
                    string[] x = i.Split(" ");
                    _ = int.TryParse(x[1], out int value);
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
                    _ = int.TryParse(directionValue[1], out int value);
                    horizonalPosition += value;
                    depthPosition = value * aim + depthPosition;
                }
                else if (direction.Contains("down "))
                {
                    string[] directionValue = direction.Split(" ");
                    _ = int.TryParse(directionValue[1], out int value);
                    aim += value;
                }
                else if (direction.Contains("up "))
                {
                    string[] directionValue = direction.Split(" ");
                    _ = int.TryParse(directionValue[1], out int value);
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
            for (int i = 0; i < input[i].Length; i++)
            {
                var digits = HelpfulTools.TheMostCommon(input, i);
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
            for (int i = 1; i < input[1].Length; i++)
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

        public static int Day4_Part1()
        {
            var input = File.ReadLines(@"C:\AOC\Day4Input.txt");
            var firstWinningCard = 0;
            var bingoBalls = new List<int>();
            var allBingoCards = new List<BingoBoard>();
            int numberOfBallsCalled = 0;
            int lastBallCalled = 0;

            foreach (var ball in input.First().Split(","))
            {
                int ballToParse = int.Parse(ball);
                bingoBalls.Add(ballToParse);
            }
            int cardID = 0;
            for (int i = 2; i < input.Count(); i += 6)
            {
                allBingoCards.Add(HelpfulTools.CardBuilder(i, cardID));
                cardID++;
            }

            var winnerslist = new List<BingoCardModel>(); //any cards who've matched a number

            foreach (var ball in bingoBalls) //loop every ball
            {
                if (numberOfBallsCalled >= 5)
                {
                    //check for a winner 
                    firstWinningCard = HelpfulTools.CheckForWinner(winnerslist);
                    if (firstWinningCard != -1)
                    {
                        break;
                    }
                }

                foreach (BingoBoard bingoCard in allBingoCards) //loop every card 
                {
                    var board = bingoCard.BoardArray;
                    for (int row = 0; row < board.Length; row++) //compare first ball to first row 
                    {
                        for (int col = 0; col < board.Length; col++) //in the first column
                        {
                            if (ball == board[row][col])
                            {
                                board[row][col] = -1; // cross off a number 
                                var recordWin = new BingoCardModel(bingoCard.CardId, row, col); 
                                winnerslist.Add(recordWin);
                                break;
                            }
                        }
                    }
                }
                numberOfBallsCalled++;
                lastBallCalled = ball;
            }

            var winningCard = allBingoCards[firstWinningCard];
            var unmarkedNumbers = 0;
            //find all unmarked numbers and sum them
            var winnerBoard = winningCard.BoardArray;
            foreach (int[] row in winnerBoard)
            {
                for (int col = 0; col < winnerBoard.Length; col++)
                {
                    if (row[col] != -1)
                    {
                        unmarkedNumbers += row[col];
                    }
                }
            }
            int answer = unmarkedNumbers * lastBallCalled;
            return answer;
        }

        public static int Day4_Part2()

        {
            var input = File.ReadLines(@"C:\AOC\Day4Input.txt");
            var bingoBalls = new List<int>();
            var allBingoCards = new List<BingoBoard>();
            int numberOfBallsCalled = 0;
            int lastBallCalled = 0;
            var cardsWhichWon = new List<int>();
            int losingCardFinally = 0;
            List<int> recordOfWinners = new();
            var ordered = new List<int>();
            bool ballFoundOnCard = false;
            bool clearedWinners = false;


            foreach (var ball in input.First().Split(","))
            {
                int ballToParse = int.Parse(ball);
                bingoBalls.Add(ballToParse);
            }
            int cardID = 0;
            for (int i = 2; i < input.Count(); i += 6)
            {
                allBingoCards.Add(HelpfulTools.CardBuilder(i, cardID));
                cardID++;
            }

            var winnerslist = new List<BingoCardModel>(); //any cards who've matched a number

            foreach (var ball in bingoBalls) //loop every ball
            {
                    if (clearedWinners == true)
                    {
                        losingCardFinally = HelpfulTools.CheckForWinner(winnerslist);
                        if (losingCardFinally != -1)
                        {
                            break;
                        }
                    }
                    //check for all winners and list them, then using that list remove all the cardid in the winnerlist
                    cardsWhichWon = HelpfulTools.CheckForWinnerALL(winnerslist);
                    if (cardsWhichWon.Count != 0)
                    {
                        foreach (var card in cardsWhichWon)
                        {
                            {
                                if (!recordOfWinners.Any(x => x == card))
                                {
                                    recordOfWinners.Add(card);
                                }
                                if (recordOfWinners.Count == 99 && clearedWinners == false) 
                                {
                                    winnerslist.RemoveAll(x => recordOfWinners.Any(recordOfWinners => x.CardId == recordOfWinners));
                                    clearedWinners = true;
                                }
                            }
                        }
                    }

                /* The loop runs through every bingo card and check if the ball is on it card
                if it is, the number on the card is turned into -1 and we exit the loop and 
                move to the next card
                */
                foreach (BingoBoard bingoCard in allBingoCards) //loop every card 
                {
                    ballFoundOnCard = false; // reset the card loop if ball was found 
                    var board = bingoCard.BoardArray;
                    for (int row = 0; row < board.Length; row++) //compare first ball to first row 
                    {
                        if (ballFoundOnCard == true)
                        {
                            break; // get out of the first for loop
                        }

                        for (int col = 0; col < board.Length; col++) //in the first column
                        {
                            if (ballFoundOnCard == true)
                            {
                                break; // get out of the last for loop
                            }

                            if (ball == board[row][col])
                            {
                                board[row][col] = -1; // cross off a number 
                                var recordWin = new BingoCardModel(bingoCard.CardId, row, col);
                                winnerslist.Add(recordWin);
                                ballFoundOnCard = true; // no need to keep checking the card
                            }
                        }
                    }
                }
                numberOfBallsCalled++;
                lastBallCalled = ball;
            }
            var losingCard = allBingoCards[losingCardFinally];
            var unmarkedNumbers = 0;
            //find all unmarked numbers and sum them
            var winnerBoard = losingCard.BoardArray;
            foreach (int[] row in winnerBoard)
            {
                for (int col = 0; col < winnerBoard.Length; col++)
                {
                    if (row[col] != -1)
                    {
                        unmarkedNumbers += row[col];
                    }
                }
            }
            int answer = unmarkedNumbers * lastBallCalled;
            return answer;
        }
    }
}
