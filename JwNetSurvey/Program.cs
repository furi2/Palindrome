using System;
using System.IO;

namespace JwNetSurvey
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = ""; 

            while (filePath == "")
            {
                if (args == null || args.Length == 0)
                {
                    Console.WriteLine("Input a path to the data file.");
                    filePath = Console.ReadLine();
                }
                else if (args.Length > 0)
                {                    
                    filePath = args[0];
                    Console.WriteLine(filePath);
                }
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("The file doesn't exist.");
                    filePath = "";
                }
            }

            Console.WriteLine("Using PalindromeEvaluator class directly:");
            IDataReader dataReader = new TextFileDataReader(filePath);
            IStringEvaluator eval = new PalindromeEvaluator(dataReader);
            Console.WriteLine("The file contains {0} palindrome(s)", eval.EvaluateAll().ToString());

            Console.WriteLine("Using StringEvaluators class:");
            StringEvaluators evalators = new StringEvaluators(dataReader);
            Console.WriteLine("The file contains {0} palindrome(s)", evalators.Palindrome.EvaluateAll().ToString());
            Console.WriteLine("The file contains {0} consonants-only expression(s)", evalators.Consonants.EvaluateAll().ToString());

            Console.ReadLine();
        }
    }
}
