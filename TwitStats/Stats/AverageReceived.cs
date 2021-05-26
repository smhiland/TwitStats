using System;
using System.Collections.Generic;
using TwitStats.Core;
using TwitStats.Data;
using TwitStats.DTO;

namespace TwitStats.Stats
{
    /// <summary>
    /// Gather the Average number of Data Points received by hour, minute, and second
    /// </summary>
    public class AverageReceived : Stat<AverageStatBaseData>
    {
        public AverageReceived() : base()
        {
            Description = "Average (hr/min/sec)";

            _baseData.SetDefault();
        }

        public AverageReceived(string description) : this()
        {
            Description = description;
        }

        /// <inheritdoc/>
        protected override void SetBaseData(IDataPoint dataPoint)
        {
            if (!_baseData.StartDateTime.HasValue)
            {
                _baseData.StartDateTime = DateTime.Now;
            }

            _baseData.TotalCount++;
        }

        /// <inheritdoc/>
        protected override IEnumerable<IStatResult> ReportStatResults(AverageStatBaseData statData)
            => new List<IStatResult> { new StatResult(Description, ResultsToString(statData)) };

        /// <inheritdoc/>
        protected override string ResultsToString(AverageStatBaseData statData)
        {
            if (statData.TotalCount <= 0)
            {
                return "No Results";
            }

            // Calculate results
            DateTime currentDateTime = DateTime.Now;
            DateTime startDateTime = statData.StartDateTime ?? currentDateTime;

            double diffSec = (currentDateTime - startDateTime).TotalSeconds;
            diffSec = diffSec == 0 ? 1 : diffSec;
            double perSecond = diffSec == 0 ? diffSec : statData.TotalCount / diffSec;

            double diffMin = (currentDateTime - startDateTime).TotalMinutes;
            double perMinute = diffMin == 0 ? diffSec * 60 : statData.TotalCount / diffMin;

            double diffHour = (currentDateTime - startDateTime).TotalHours;
            double perHour = diffHour == 0 ? diffMin * 60 : statData.TotalCount / diffHour;


            return $"{perHour:n0} / {perMinute:n0} / {perSecond:n0}";
        }

        /// <inheritdoc/>
        protected override void ResetBaseData()
        {
            _baseData.StartDateTime = null;
            _baseData.TotalCount = 0;
        }

        /// <inheritdoc/>
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
