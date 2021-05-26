using System;
using System.Collections.Generic;
using TwitStats.Core;
using TwitStats.DTO;

namespace TwitStats.Stats
{
    /// <summary>
    /// Gather the Total number of Data Points received
    /// </summary>
    public class TotalStat : Stat<long>
    {
        public TotalStat() : base()
        {
            Description = "Total";
            _baseData = 0;
        }

        public TotalStat(string description) : this()
        {
            Description = description;
        }

        /// <inheritdoc/>
        protected override void SetBaseData(IDataPoint dataPoint)
        {
            _baseData++;
        }

        /// <inheritdoc/>
        protected override IEnumerable<IStatResult> ReportStatResults(long statData)
            => new List<IStatResult> { new StatResult(Description, ResultsToString(statData)) };

        /// <inheritdoc/>
        protected override string ResultsToString(long statData)
        {
            if (statData > 0)
            {
                return statData.ToString("n0");
            }
            else
            {
                return "No Results";
            }
        }

        /// <inheritdoc/>
        protected override void ResetBaseData()
        {
            _baseData = 0;
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            base.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
