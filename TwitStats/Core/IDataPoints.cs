using System;
using System.Collections.Generic;

namespace TwitStats.Core
{
    /// <summary>
    /// Data Points being captured
    /// </summary>
    public interface IDataPoints : IEnumerable<IDataPoint>
    {
        /// <summary>
        /// Search the list for matches
        /// </summary>
        /// <param name="testFunc">Method to test for string match</param>
        /// <returns>
        /// New collection of DataPoints which contain the search criteria
        /// </returns>
        IDataPoints Contains(Func<string, IEnumerable<string>> testFunc);

        /// <summary>
        /// Get matches in the string
        /// </summary>
        /// <param name="testFunc">Function to determine matches</param>
        /// <returns>
        /// New collection of DataPoints which contain the search criteria
        /// </returns>
        IDataPoints GetMatches(Func<string, IEnumerable<string>> testFunc);

        /// <summary>
        /// Get the frequency in-which the search criteria is found
        /// </summary>
        /// <returns>
        /// New collection of DataPoints which contain the search criteria
        /// Ordered in DESC order by frequency
        /// </returns>
        IDataPoints Frequency();

        /// <summary>
        /// Clear the collection of DataPoints
        /// </summary>
        void Clear();

        /// <summary>
        /// Get the number of elements in the collection
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Add a data point to the collection
        /// </summary>
        /// <param name="dataPoint">Data Point to add</param>
        void Add(IDataPoint dataPoint);

    }
}
