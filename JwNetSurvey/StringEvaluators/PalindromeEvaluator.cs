using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwNetSurvey
{
    public class PalindromeEvaluator : StringEvaluator
    {
        StringBuilder _buffer = new StringBuilder();

        public PalindromeEvaluator(IDataReader dataReader)
            : base(dataReader)
        { }

        override public bool Evaluate(string expr)
        {
            if (String.IsNullOrEmpty(expr)) { return false; }
            expr = expr.ToLower();
            expr = EliminateExtraChars(expr);

            for (int i = 0, j = expr.Length - 1; i <= j; i++, j--)
            {
                if (expr[i] != expr[j])
                {
                    return false;
                }
            }
            return true;
        }

        string EliminateExtraChars(string expr)
        {
            _buffer.Clear();
            foreach (var c in expr.ToCharArray())
            {
                if (Char.IsLetterOrDigit(c))
                {
                    _buffer.Append(c);
                }
            }
            return _buffer.ToString();
        }
    }
}
