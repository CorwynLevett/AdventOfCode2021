using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC___2021
{
    public class CharChecker
    {
        public static string WhatsTheMostCommon(string[] input, int startPosition, int stopPosition)
        {
            int zeroCount = 0;
            int oneCount = 0;
            string mostCommmonBit = "";
            for (int i = 0; i < input.Length; i++)
            {

                if (input[i].Substring(startPosition, stopPosition) == "0")
                {
                    zeroCount++;
                }
                else if (input[i].Substring(startPosition, stopPosition) == "1")
                {
                    oneCount++;
                }
            }
            if (zeroCount > oneCount)
            {
                mostCommmonBit = "0";
            }
            else
            {
                mostCommmonBit = "1";
            }

            return mostCommmonBit;
        }

        public static string InvertBinary(string binary)
        {
            char[] arr = binary.ToCharArray(); 
            string invert = "";
            foreach (char digit in arr)
            {
                if (digit.Equals('1'))
                {
                    invert += "0";
                }
                else if (digit.Equals('0'))
                {
                    invert += "1";
                }
            }
            return invert;
        }
    }
}
