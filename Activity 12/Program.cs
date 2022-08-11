using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity_12
{
    public class Program
    {

        static void Main(string[] args)
        {
            string[] words = ReadFile();
            int wordTally = TallyTsAndEs(words);
            Console.WriteLine("Total words ending in 't' or 'e': " + wordTally);
        }

        //Method to read text file and return as string arraay
        static string[] ReadFile()
        {
            try
            {
                //Instantiate and Initialize StreamReader
                StreamReader inputFile;
                inputFile = File.OpenText("words.in");

                //Read all text in file, separate into array by word using split function
                string[] wordArray = inputFile.ReadToEnd().Split(' ');

                //close reader
                inputFile.Close();
                
                //loop through and clean up words, removing excess non-alpha characters and moving to lowercase
                for (int i = 0; i < wordArray.Length; i++)
                {
                    wordArray[i] = WordCleanUp(wordArray[i]);
                }

                //return wordArray
                return wordArray;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                System.Environment.Exit(1);
            }

            //empty return, should not complete
            return null;
        }

        //method to clean up individual words, moving to lowercase and removing non-alpha characters
        static string WordCleanUp(string s)
        {
            s = s.ToLower();
            s = String.Concat(s.Where(char.IsLetter));
            return s;
        }

        //method to tally words ending in t or e
        static int TallyTsAndEs(string[] words)
        {
            //initalize counter
            int tally = 0;

            //iterate through each word in array
            foreach (string word in words)
            {
                //get last index for each word
                int lastIndex = word.Length - 1;
                //check if letter at lastIndex is a t or e, and increment tally if true
                if (word[lastIndex] == 't' || word[lastIndex] == 'e')
                {
                    tally++;
                }
            }

            //return final tally count
            return tally;
        }
    }
}
