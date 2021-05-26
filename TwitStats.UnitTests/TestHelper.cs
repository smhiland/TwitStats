using System.Collections.Generic;
using TwitStats.Core;
using TwitStats.DTO;
using TwitStats.Stats;

namespace TwitStats.UnitTests
{
    internal static class TestHelper
    {

        public static IDataPoints CreateDataPoints()
        {
            return new DataPoints()
            {
                new DataPoint() { Text = "This is a😤 Data Point" },
                new DataPoint() { Text = "Data Point with https://www.google.com/" },
                new DataPoint() { Text = "Data Point with http://www.google.com/" },
                new DataPoint() { Text = "Data Point with https://www.instagram.com/mypic1" },
                new DataPoint() { Text = "Data Point with https://www.instagram.com/mypic2" },
                new DataPoint() { Text = "Data Point with https://www.instagram.com/mypic3" },
                new DataPoint() { Text = "Data Point with https://www.instagram.com/mypic4" },
                new DataPoint() { Text = "Data Point with https://www.pic.twitter.com/mypic1" },
                new DataPoint() { Text = "Data Point with https://www.pic.twitter.com/mypic2" },
                new DataPoint() { Text = "Data Point with https://www.pic.twitter.com/mypic3" },
                new DataPoint() { Text = "Data Point with https://www.pic.twitter.com/mypic4" },
                new DataPoint() { Text = "Data Point with https://www.pic.twitter.com/mypic5" },
                new DataPoint() { Text = "Data Point with #OneHashtag" },
                new DataPoint() { Text = "Data Point 😱😤👌 with #OneHashtag #TwoHashtag" },
                new DataPoint() { Text = "Data point with # no hashtag" },
                new DataPoint() { Text = "Data Point with htp:/whatlookslike/web/address" },
                new DataPoint() { Text = "Data Point with #OneHashtag #TwoHashtag" },
                new DataPoint() { Text = "Data Point with #OneHashtag #TwoHashtag" },
                new DataPoint() { Text = "Data Point with #OneHashtag #FourHashtag" },
                new DataPoint() { Text = "Data Point with #OneHashtag #TwoHashtag" },
                new DataPoint() { Text = "Data Point with #OneHashtag #ThreeHashtag 😤" },
                new DataPoint() { Text = "🤓 #CodingChallenge #CodingChallenge. 🧠 💪💪💪💪💪 😆🤓" },
                new DataPoint() { Text = "" },
                new DataPoint() { Text = null },
                null
            }; 
        }

        public static CaseData CreateBaseCase()
        {
            CaseData rtn = new();
            rtn.DataPoints = CreateDataPoints();

            rtn.TotalHashtagCount = 15;
            rtn.TotalUrlCount = 11;
            rtn.TotalEmojiCount = 14;
            rtn.TotalWithEmoji = 4;

            rtn.TotalPhotoUrlCount = 9;
            rtn.PhotoDomains = null;

            rtn.TopCount = 3;

            rtn.Results = new Dictionary<string, IList<IStatResult>>();

            rtn.Results.Add("top_emoji",
                new List<IStatResult>() {
                    new StatResult("", "💪"),
                    new StatResult("", "😤"),
                    new StatResult("", "🤓"),
                    new StatResult("", "😱"),
                    new StatResult("", "👌"),
                    new StatResult("", "😆"),
                    new StatResult("", "🧠")
                }
            );

            rtn.Results.Add("top_hashtag",
                new List<IStatResult>() {
                    new StatResult("", "#OneHashtag"),
                    new StatResult("", "#TwoHashtag"),
                    new StatResult("", "#CodingChallenge"),
                    new StatResult("", "#ThreeHashtag"),
                    new StatResult("", "#FourHashtag")
                }
            );

            rtn.Results.Add("top_domains",
                new List<IStatResult>() {
                    new StatResult("", "www.pic.twitter.com"),
                    new StatResult("", "www.instagram.com"),
                    new StatResult("", "www.google.com")
                }
            );

            return rtn;
        }

        public static CaseData CreateCaseData_1()
        {
            CaseData rtn = CreateBaseCase();

            return rtn;
        }

        public static CaseData CreateCaseData_2()
        {
            CaseData rtn = CreateBaseCase();

            rtn.TotalPhotoUrlCount = 5;
            rtn.PhotoDomains = new List<string>() { "pic.twitter.com"};

            rtn.TopCount = 0;

            return rtn;
        }

        public static CaseData CreateCaseData_3()
        {
            CaseData rtn = CreateBaseCase();

            rtn.TotalPhotoUrlCount = 4;
            rtn.PhotoDomains = new List<string>() { "instagram.com" };

            rtn.TopCount = 2;

            return rtn;
        }
    }
}
