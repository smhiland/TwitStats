using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TwitStats.Core;
using TwitStats.Stats;

namespace TwitStats.UnitTests.Stats
{
    public class PercentEmojiTests
    {
        CaseData caseData;

        [SetUp]
        public void Setup()
        {
            caseData = TestHelper.CreateCaseData_1();
        }

        [Test]
        public void Stat_New()
        {
            Assert.IsTrue(!string.IsNullOrWhiteSpace((new PercentEmojis()).Description));
        }

        [Test]
        [TestCase("Test")]
        [TestCase("Test Stat")]
        public void Stat_NewWithDescription(string description)
        {
            Assert.AreEqual(description, (new PercentEmojis(description)).Description);
        }

        [Test]
        [TestCase("Percent", 1)]
        [TestCase("Percent", 6)]
        [TestCase("Percent", 1000)]
        [TestCase("Percent", 50)]
        [TestCase("Percent", 0)]
        public void Stat_Gather(string description, int gatherLoopCount)
        {
            PercentEmojis _stat = new(description);
            IEnumerable<IDataPoint> dataPoints = caseData.DataPoints;
            int dpCount = dataPoints.Count() * gatherLoopCount;
            long totalUrlCount = caseData.TotalWithEmoji * gatherLoopCount;

            string expectedResults = $"{description}: No Results";

            if (gatherLoopCount > 0)
            {
                expectedResults = Results(description, totalUrlCount, dpCount);
            }

            for (int x = 0; x < gatherLoopCount; x++)
            {
                foreach(IDataPoint dataPoint in dataPoints)
                {
                    _stat.Gather(dataPoint);
                }
            }

            string results = _stat.ToString();

            Assert.AreEqual(expectedResults, results);
        }

        [Test]
        [TestCase("Percent", 6)]
        [TestCase("Percent", 1)]
        [TestCase("Percent", 1000)]
        [TestCase("Percent", 1000000)]
        [TestCase("Percent", 50)]
        [TestCase("Percent", 0)]
        public void Stat_Reset(string description, int gatherLoopCount)
        {
            string expectedResults = $"{description}: No Results";
            PercentEmojis _stat = new(description);

            for (int x = 0; x < gatherLoopCount; x++)
            {
                _stat.Gather(null); // stat only cares about a count
            }

            _stat.Reset();

            Assert.AreEqual(expectedResults, _stat.ToString());
        }

        private string Results(string description, long matchCount, int totalCount)
        {
            return $"{description}: {matchCount:n0}/{totalCount:n0} = {(matchCount / (double)totalCount):p2}";
        }
    }
}