using System;

namespace JwNetSurvey
{
    public interface IStringEvaluator
    {
        IDataReader DataReader { get; set; }

        /// <summary>
        /// Default method to be called for evaluation.
        /// </summary>
        Func<string, bool> Evaluator { get; set; }

        /// <summary>
        /// Calls Evaluate method for all the records.
        /// </summary>
        /// <returns>Number of record where the evaluation returned true.</returns>
        int EvaluateAll();

        /// <summary>
        /// Evaluate the expression. The default method calls Evaluator if exists, otherwise false.
        /// Override this method to customise.
        /// </summary>
        /// <param name="expression">A string expression to be evaluated.</param>
        /// <returns>true if matches, otherwise false.</returns>
        bool Evaluate(string expression);
    }


    
}
