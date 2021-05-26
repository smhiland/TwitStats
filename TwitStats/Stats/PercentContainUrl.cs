using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TwitStats.Core;
using TwitStats.Data;
using TwitStats.Helpers;

namespace TwitStats.Stats
{
    /// <summary>
    /// Gather the Percent of Tweets which contain a URL
    /// </summary>
    public class PercentContainUrl : MatchStat
    {

        /// <inheritdoc/>
        public PercentContainUrl() : base()
                => Description = "% with URL";

        /// <inheritdoc/>
        public PercentContainUrl(string description) : base(description) { }

        /// <inheritdoc/>
        protected override IDataPoints GetMatches(Datum statData)
                => statData.Data.Contains(PullMatches);

        /// <inheritdoc/>
        protected override IEnumerable<string> PullMatches(string s)
            => base.PullMatches(Regex.Match(s ?? string.Empty, UrlHelper.UrlRegexFilter).Value);

        /// <inheritdoc/>
        protected override string PrintResult(Datum statData)
        {
            IDataPoints dataPoints = GetMatches(statData);
            int matchCount = dataPoints.Count();

            return $"{matchCount:n0}/{statData.TotalCount:n0} = {(matchCount / (double)statData.TotalCount):p2}";
        }
    }
}
