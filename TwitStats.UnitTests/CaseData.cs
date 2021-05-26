using System.Collections.Generic;
using TwitStats.Core;

namespace TwitStats.UnitTests
{
    internal class CaseData
    {
        public IDataPoints DataPoints { get; set; }

        public int TotalUrlCount { get; set; }

        public int TotalPhotoUrlCount { get; set; }

        public int TotalHashtagCount { get; set; }

        public int TotalEmojiCount { get; set; }

        public int TotalWithEmoji { get; set; }

        public IEnumerable<string> PhotoDomains { get; set; }

        public int? TopCount { get; set; }

        public IDictionary<string, IList<IStatResult>> Results { get; set; }

    }
}
