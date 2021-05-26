using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TwitStats.Core;
using TwitStats.Helpers;
using TwitStats.Stats;

namespace TwitStats.UnitTests.Stats
{
    public class TopHashtagsTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Stat_New()
        {
            Assert.IsTrue(!string.IsNullOrWhiteSpace((new TopHashtags()).Description));
        }

        [Test]
        [TestCase("Test")]
        [TestCase("Test Stat")]
        public void Stat_NewWithDescription(string description)
        {
            Assert.AreEqual(description, (new TopHashtags(description)).Description);
        }

        [Test]
        [TestCase("Top hashtags", 3, "top_hashtag")]
        public void Stat_Gather(string description, int defaultTopCount, string resultDictKey)
        {

            List<CaseData> caseDatas = new()
            {
                TestHelper.CreateCaseData_1(),
                TestHelper.CreateCaseData_2(),
                TestHelper.CreateCaseData_3()
            };

            foreach (CaseData caseData in caseDatas)
            {
                IDataPoints dataPoints = caseData.DataPoints;
                TopHashtags _stat;
                int topcount = (caseData.TopCount ?? 0) <= 0 ? defaultTopCount : caseData.TopCount.Value;

                if (caseData.TopCount.HasValue)
                {
                    _stat = new(description, caseData.TopCount.Value);
                }
                else
                {
                    _stat = new(description);
                }

                foreach (IDataPoint dataPoint in dataPoints)
                {
                    _stat.Gather(dataPoint);
                }

                IEnumerable<IStatResult> results = _stat.GetResults();

                IList<IStatResult> expectedResults = caseData.Results[resultDictKey];

                Assert.AreEqual(topcount, results.Count());

                int x = 0;
                foreach (IStatResult result in results)
                {
                    string expected = expectedResults[x++].Value;
                    string actual = result.Value;
                    Assert.AreEqual(expected, actual);
                }

            }
        }

        [Test]
        [TestCase("Percent", 6)]
        [TestCase("Percent", 6)]
        [TestCase("Percent", 1)]
        [TestCase("Percent", 1000)]
        [TestCase("Percent", 1000000)]
        [TestCase("Percent", 50)]
        [TestCase("Percent", 0)]
        public void Stat_Reset(string description, int gatherLoopCount)
        {
            string expectedResults = $"{description}: No Results";
            TopHashtags _stat = new(description);

            for (int x = 0; x < gatherLoopCount; x++)
            {
                _stat.Gather(null);
            }

            _stat.Reset();

            Assert.AreEqual(expectedResults, _stat.ToString());
        }
    }
}