using System;
using System.Collections.Generic;
using TwitStats.Core;
using TwitStats.Data;
using TwitStats.DTO;

namespace TwitStats.Stats
{
    /// <summary>
    /// Gather the Total number of Data Points received
    /// </summary>
    public abstract class MatchStat : Stat<Datum>
    {
        /// <summary>
        /// Determine if the passed string is a match
        /// </summary>
        /// <param name="dataPoint">String to inspect</param>
        /// <returns>Collection of strings which are matching</returns>
        protected virtual IEnumerable<string> PullMatches(string dataPoint)
        {
            IList<string> rtn = new List<string>();

            if (!string.IsNullOrWhiteSpace(dataPoint))
            {
                rtn.Add(dataPoint);
            }

            return rtn;
        }

        /// <summary>
        /// Get Matches for the Stat
        /// </summary>
        /// <param name="statData">Base data for the Stat</param>
        /// <returns>Strings which match</returns>
        protected abstract IDataPoints GetMatches(Datum statData);

        /// <summary>
        /// Get a string to represent the results of the Stat
        /// </summary>
        /// <param name="statData">Base data for the Stat</param>
        /// <returns>String which represents the results of the Stat</returns>
        protected abstract string PrintResult(Datum statData);

        public MatchStat() : base()
        {
            _baseData.SetDefault();
        }

        public MatchStat(string description) : this()
            => Description = string.IsNullOrWhiteSpace(description) ? Description : description; 

        /// <inheritdoc/>
        protected override void SetBaseData(IDataPoint dataPoint)
        {
            _baseData.TotalCount++;
            _baseData.Data.Add(dataPoint);
        }

        /// <inheritdoc/>
        protected override IEnumerable<IStatResult> ReportStatResults(Datum statData)
            => new List<IStatResult> { new StatResult(Description, ResultsToString(statData)) };

        /// <inheritdoc/>
        protected override string ResultsToString(Datum statData)
        {
            if (statData.TotalCount <= 0 || statData.Data.Count <= 0)
            {
                return "No Results";
            }

            return PrintResult(statData);
        }

        /// <inheritdoc/>
        protected override void ResetBaseData()
        {
            _baseData.TotalCount = 0;
            _baseData.Data.Clear();
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            base.Dispose();
            GC.SuppressFinalize(this);
            _baseData.Data.Clear();
        }
    }
}
