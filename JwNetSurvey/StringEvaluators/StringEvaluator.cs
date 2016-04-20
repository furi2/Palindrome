using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwNetSurvey
{

    /// <summary>
    /// Base class for other classes that implement IStringEvaluator
    /// </summary>
    public class StringEvaluator : IStringEvaluator
    {
        public IDataReader DataReader { get; set; }
        public Func<string, bool> Evaluator { get; set; }

        public StringEvaluator(IDataReader dataReader)
        {
            DataReader = dataReader;
        }
        public StringEvaluator(IDataReader dataReader, Func<string, bool> evaluator)
            : this(dataReader)
        {
            Evaluator = evaluator;
        }

        ~StringEvaluator()
        {
            DataReader.Dispose();
        }

        virtual public bool Evaluate(string expr)
        {
            if (Evaluator != null)
                return Evaluator(expr);
            else {
                return false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns>Number of expressions evaluated as true in Evaluator</returns>
        virtual public int EvaluateAll()
        {
            string line;
            int c = 0;
            int numLine = 1;

            using (var reader = DataReader.Init())
            {
                while ((line = DataReader.ReadLine()) != null)
                {
                    if (Evaluate(line))
                    {
                        Debug.WriteLine(numLine.ToString() + @" : """ + line + @""" was evaluated as true.");
                        c++;
                    }
                    numLine++;
                }
            }
            return c;
        }
    }
}
