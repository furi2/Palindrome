using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwNetSurvey
{
    public class ConsonantsEvaluator : StringEvaluator
    {
        static readonly List<char> VOWLES = new List<char>("aeiou");

        public ConsonantsEvaluator(IDataReader dataReader)
            : base(dataReader)
        { }

        public override bool Evaluate(string expr)
        {
            expr = expr.ToLower();            
            foreach (var v in VOWLES) {
                if (expr.Contains(v))
                    return false; 
            }
            return true;
        }
    }
}
