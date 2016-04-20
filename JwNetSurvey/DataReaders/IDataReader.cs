using System;
using System.Collections.Generic;
namespace JwNetSurvey
{
    public interface IDataReader : IDisposable
    {
        /// <summary>
        /// Initialize the data reader. Call this method in "using" clause.
        /// </summary>
        /// <returns>The initialized IDataReader instance</returns>
        IDataReader Init();

        /// <summary>
        /// Read next string line from the data source.
        /// </summary>
        /// <returns>A string or null when no more data to read.</returns>
        String ReadLine();


        /// <summary>
        /// true if no more data to read
        /// </summary>
        bool EndOfData { get; }
    }
}
