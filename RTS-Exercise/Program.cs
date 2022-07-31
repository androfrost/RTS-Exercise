using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // aboveBelow
            // Class to store returned values
            ReturnedValue rv = new ReturnedValue();
            List<int> testIntegerList = new List<int>();
            testIntegerList.Add(6);
            testIntegerList.Add(1);
            testIntegerList.Add(4);
            testIntegerList.Add(8);
            testIntegerList.Add(9);
            testIntegerList.Add(5);
            rv.valueMap = aboveBelow(testIntegerList, 8);

            rv.rotatedString = stringRotation("teststring", 4);
        }

        // Places the number of records above the comparison value and those below into a dictionary
        private static Dictionary<string, int> aboveBelow(List<int> integerList, int comparisonValue)
        {
            Dictionary<string, int> compMap = new Dictionary<string, int>();

            integerList.Sort();  // Sort list
            int listLength = integerList.Count;
            int below = 0, above = 0;
            // Loop until sorted list reaches a record that is greater than the comparison value and then set the variables above the comparison value and below appropriately
            for (int intx = 0; intx < listLength; intx++)
            {
                if (integerList[intx] < comparisonValue)
                {
                    below++;
                }

                if (integerList[intx] > comparisonValue)
                {
                    above = listLength - intx;
                    break;
                }
            }
            compMap.Add("above", above);
            compMap.Add("below", below);

            return compMap;
        }

        // Rotate characters from a given string from the end to the beginning based on a given number of characters
        private static string stringRotation(string rotateString, int charactersToRotate)
        {
            
            string returnString = "", startString = "", endString = "";
            int stringLength = rotateString.Length;

            // Exit if rotation characters are less then 0
            if (charactersToRotate < 0)
            {
                return returnString;
            }
            charactersToRotate = charactersToRotate % rotateString.Length;

            // Find new string concatenation
            startString = rotateString.Substring(0, stringLength - charactersToRotate);
            endString = rotateString.Substring(stringLength - charactersToRotate, charactersToRotate);
            returnString = endString + startString;

            return returnString;
        }

        // Stored values returned from functions
        public class ReturnedValue
        {
            public Dictionary<string, int> valueMap { get; set; }
            public string rotatedString { get; set; }
        }
}

}
