using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TwitStats.Core;
using TwitStats.Data;
using TwitStats.DTO;

namespace TwitStats.Stats
{
    /// <summary>
    /// Base class to gather the Top Stats of Data
    /// </summary>
    public abstract class TopStats : MatchStat
    {
        readonly int _topCount = 3;

        public TopStats() : base() { }

        public TopStats(string description) : base(description) { }

        /// <summary>
        /// Create a Top type Stat
        /// </summary>
        /// <param name="topCount">Number of Top entries to display</param>
        public TopStats(string description = null,  int topCount = 3) : base(description)
        {
            if (topCount > 0) 
            {
                _topCount = topCount;
            }
        }

        /// <inheritdoc/>
        protected override IEnumerable<IStatResult> ReportStatResults(Datum statData)
        {
            IDataPoints t = GetMatches(statData);
            IEnumerable<IDataPoint> matches = GetMatches(statData).Frequency().Take(_topCount);
            List<IStatResult> rtn = new();
            if (matches.Any())
            {
                int idx = 0;
                foreach (IDataPoint dp in matches)
                {
                    rtn.Add(new StatResult((++idx).ToString("n0"), dp.Text));
                }
            }

            return rtn;
        }

        /// <inheritdoc/>
        protected override string PrintResult(Datum statData)
            => PrintTops(ReportStatResults(statData));

        internal static string PrintTops(IEnumerable<IStatResult> results)
        {
            if (results.Any())
            {
                StringWriter sw = new();
                foreach (IStatResult dp in results)
                {
                    sw.Write(Environment.NewLine);
                    sw.Write($"{dp.Description}: {dp.Value}");
                }

                return sw.ToString();
            }
            else
            {
                return "No Results";
            }
        }
    }
}
