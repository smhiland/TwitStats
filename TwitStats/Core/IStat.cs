using System;
using System.Collections.Generic;

namespace TwitStats.Core
{
    /// <summary>
    /// Interface for Stat
    /// </summary>
    public interface IStat : IDisposable
    {
        /// <summary>
        /// Description of the Stat
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gather Data Point for the Stat
        /// </summary>
        /// <param name="dataPoint">Data Point received</param>
        void Gather(IDataPoint dataPoint);

        /// <summary>
        /// Results of the Stat
        /// </summary>
        /// <returns>String representing the results</returns>
        protected string Results() => string.Empty;

        /// <summary>
        /// Reset the Stat base data to start fresh
        /// </summary>
        void Reset();

        /// <summary>
        /// Get a list of the results
        /// </summary>
        /// <returns>List of the Stat's results</returns>
        IEnumerable<IStatResult> GetResults();
    }
}
