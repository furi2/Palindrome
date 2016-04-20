using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JwNetSurvey
{
    public class PalindromeEvaluator : StringEvaluator
    {
        static readonly Regex _regex = new Regex("[^a-zA-Z0-9]");

        public PalindromeEvaluator(IDataReader dataReader)
            : base(dataReader)
        { }

        override public bool Evaluate(string expr)
        {
            if (String.IsNullOrEmpty(expr)) { return false; }
            
            expr = expr.ToLower();            
            expr = _regex.Replace(expr, "");

            for (int i = 0, j = expr.Length - 1; i <= j; i++, j--)
            {
                if (expr[i] != expr[j])
                {
                    return false;
                }
            }
            return true;
        }

        
    }
}
