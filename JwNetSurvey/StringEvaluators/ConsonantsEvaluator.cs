using System.Linq;
using System.Text.RegularExpressions;

namespace JwNetSurvey
{
    public class ConsonantsEvaluator : StringEvaluator
    {
        static readonly Regex _regex = new Regex("[aeiou]");

        public ConsonantsEvaluator(IDataReader dataReader)
            : base(dataReader)
        { }

        public override bool Evaluate(string expr)
        {
            expr = expr.ToLower();            
            return !_regex.IsMatch(expr);
        }
    }
}
