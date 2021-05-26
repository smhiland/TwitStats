using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TwitStats.Core;
using TwitStats.Data;
using TwitStats.Helpers;

namespace TwitStats.Stats
{
    /// <summary>
    /// Gather the Top Domains found in Data
    /// </summary>
    public class TopDomains : TopStats
    {

        /// <inheritdoc/>
        public TopDomains() : base()
            => Description = "Top Domains";

        /// <inheritdoc/>
        public TopDomains(string description) : base(description) { }

        /// <inheritdoc/>
        public TopDomains(string description = null, int topCount = 3) : base(description, topCount) { }

        /// <inheritdoc/>
        protected override IDataPoints GetMatches(Datum statData)
            => DataPoints.ParseStrings(UrlHelper.GetDomains(statData.Data, PullMatches));

        /// <inheritdoc/>
        protected override IEnumerable<string> PullMatches(string s)
            => Regex.Matches(s ?? string.Empty, UrlHelper.UrlRegexFilter)
                    .Select(m => m.Value);
    }
}
