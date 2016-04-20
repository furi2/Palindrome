using System;
using System.Collections.Generic;
using System.Collections;

namespace JwNetSurvey
{
    /// <summary>
    /// This class is a wrapper class just to make it simpler to access all the StringEvaluator classes using one resource.
    /// </summary>
    public class StringEvaluators
    {       
        IDataReader DataReader { get; set; }
        List<IStringEvaluator> Evaluators { get; } = new List<IStringEvaluator>();
        public PalindromeEvaluator Palindrome {get;}
        public ConsonantsEvaluator Consonants { get; }


        public StringEvaluators(IDataReader dataReader)
        {
            Palindrome = new PalindromeEvaluator(dataReader);
            Consonants = new ConsonantsEvaluator(dataReader);
            Evaluators.Add(Palindrome);
            Evaluators.Add(Consonants);
        } 
    }
}
