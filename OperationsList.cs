using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzz
{
    class OperationsList
    {
        //Search words containing a given string;
        public List<string> SearchWordsContainingGivenString(string[] wordsList, string searchableString)
        {
            List<string> wordsContainingGivenString = new List<string>();
            foreach (string word in wordsList)
            {
                if (word.Contains(searchableString.ToLower()))
                {
                    wordsContainingGivenString.Add(word);
                }
            }

            return wordsContainingGivenString;
        }

        // Search odd numbers in a given list;
        public List<int> OddNumbers(int[] numbers)
        {
            List<int> oddNumbers = new List<int>();
            oddNumbers = (numbers.Where(i => i % 2 != 0)).ToList();

            return oddNumbers;
        }

        private List<int> GetMultiplesOfNumber(int number)
        {
            List<int> multiples = new List<int>();

            for (int i = 1; number * i <= 100; i++)
            {
                multiples.Add(number * i);
            }

            return multiples;
        }

        public KeyValuePair<int, string>[] WordsToPrintV2()
        {
            List<int> m3 = GetMultiplesOfNumber(3);
            List<int> m5 = GetMultiplesOfNumber(5);
            List<int> m1 = GetMultiplesOfNumber(1);
            Dictionary<int, string> listToPrint = new Dictionary<int, string>();

            foreach(int number in m3 )
            {
                listToPrint.Add(number, "Fizz" + number);
            }

            foreach (int number in m5)
            {
                if (listToPrint.ContainsKey(number))
                {
                    listToPrint[number] = "FizzBuzz" + number;
                }
                else
                {
                    listToPrint.Add(number, "Buzz" + number);
                }
            }

            foreach (int number in m1)
            {
                if (!listToPrint.ContainsKey(number))
                {
                    listToPrint.Add(number, number.ToString());
                }
            }

            KeyValuePair<int, string> [] orderedDict = listToPrint.OrderBy(x => x.Key).Take(listToPrint.Count).ToArray();

            return orderedDict;
        }

        //Iterate for all numbers from 1 to 100 and create a list with respective words
        public List<string> WordsToPrintV1 (Dictionary<int, string> multiplesWord)
        {
            List<string> wordsToPrint = new List<string>();

            for (int i = 1; i <= 100; i++)
            {
                wordsToPrint.Add(FindWord(i, multiplesWord));
            }

            return wordsToPrint;
        }

        private string FindWord(int currentNumber, Dictionary<int, string> multiplesWord)
        {
            string currentWord = string.Empty;
            
            //Sort the dictionary to assure that in case of the number have more than one multiple, the words are added by order
            
            var orderedDict = multiplesWord.OrderBy(pair => pair.Key).Take(multiplesWord.Count);

            foreach (KeyValuePair<int, string> kvp in orderedDict)
            {
                if(currentNumber % kvp.Key == 0)
                {
                    currentWord += kvp.Value;
                }
            }
            
           currentWord += currentNumber.ToString();

            return currentWord;
        }
    }
}
