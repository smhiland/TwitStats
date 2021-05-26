using System;

namespace TwitStats.Core
{
    /// <summary>
    /// Interface of Harvester of Stats
    /// </summary>
    public interface IHarvester : IEventHost, IDisposable
    {
        /// <summary>
        /// Start Harvesting
        /// </summary>
        void Start();

        /// <summary>
        /// Stop Harvesting
        /// </summary>
        void Stop();

        /// <summary>
        /// Register Stat to Harvest
        /// </summary>
        /// <param name="stat">IStat object which contains data of stat</param>
        IHarvester RegisterStat(IStat stat);

        /// <summary>
        /// Unregister Stat to Harvest
        /// </summary>
        /// <param name="stat">IStat object which contains data of stat</param>
        IHarvester UnRegisterStat(IStat stat);

        /// <summary>
        /// Get Stat result data to display
        /// </summary>
        /// <param name="stat">IStat object which contains data of stat</param>
        /// <returns>String representing stat data</returns>
        string GetStatResult(IStat stat);

        /// <summary>
        /// Get all Stats' result data to display
        /// </summary>
        /// <returns>String representing all stat data</returns>
        string GetStatsResults();

        /// <summary>
        /// Reset all Stats' data to start fresh
        /// </summary>
        void Reset();

        /// <summary>
        /// Reset single Stat data to start fresh
        /// </summary>
        /// <param name="stat">IStat object which contains data of stat</param>
        void Reset(IStat stat);
    }
}
