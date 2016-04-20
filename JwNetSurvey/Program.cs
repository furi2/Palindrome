using System;
using System.IO;

namespace JwNetSurvey
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "UKACD17.TXT";
            bool valid = false;
            IDataReader dataReader;
            IStringEvaluator eval;
            StringEvaluators evalators;
            int count;

            while (!valid)
            {
                valid = File.Exists(filePath);
                if (!valid)
                {
                    Console.WriteLine("{0} doesn't exist.", filePath);
                    Console.WriteLine("Input a path to the data file.");
                    filePath = Console.ReadLine();
                }
            }

            Console.WriteLine("Data source : {0} ", filePath);

            Console.WriteLine("\nUsing PalindromeEvaluator class directly:");
            dataReader = new TextFileDataReader(filePath);
            eval = new PalindromeEvaluator(dataReader);
            count = eval.EvaluateAll();
            Console.WriteLine("Found {0} palindrome(s)", count);

            Console.WriteLine("\nUsing StringEvaluators class:");
            evalators = new StringEvaluators(dataReader);
            count = evalators.Palindrome.EvaluateAll();
            Console.WriteLine("Found {0} palindrome(s)", count);
            count = evalators.Consonants.EvaluateAll();
            Console.WriteLine("Found {0} consonants-only expression(s)", count);

            Console.ReadLine();
        }
    }
}
