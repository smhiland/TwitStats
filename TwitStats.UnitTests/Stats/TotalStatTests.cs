using NUnit.Framework;
using TwitStats.Stats;

namespace TwitStats.UnitTests.Stats
{
    public class TotalStatTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Stat_New()
        {
            Assert.IsTrue(!string.IsNullOrWhiteSpace((new TotalStat()).Description));
        }

        [Test]
        [TestCase("Test")]
        [TestCase("Total Stat")]
        public void Stat_NewWithDescription(string description)
        {
            Assert.AreEqual(description, (new TotalStat(description)).Description);
        }

        [Test]
        [TestCase("Total", 6, "Total: 6")]
        [TestCase("Total Count", 3, "Total Count: 3")]
        [TestCase("Total", 1, "Total: 1")]
        [TestCase("Total", 1000, "Total: 1,000")]
        [TestCase("Total", 1000000, "Total: 1,000,000")]
        [TestCase("Total", 50, "Total: 50")]
        [TestCase("Total", 0, "Total: No Results")]
        public void Stat_Gather(string description, int gatherLoopCount, string expectedResults)
        {
            TotalStat _stat = new(description);

            for(int x = 0; x < gatherLoopCount; x++)
            {
                _stat.Gather(null); // stat only cares about a count
            }

            Assert.AreEqual(expectedResults, _stat.ToString());
        }

        [Test]
        [TestCase("Total", 6)]
        [TestCase("Total Count", 3)]
        [TestCase("Total", 1)]
        [TestCase("Total", 1000)]
        [TestCase("Total", 1000000)]
        [TestCase("Total", 50)]
        [TestCase("Total", 0)]
        public void Stat_Reset(string description, int gatherLoopCount)
        {
            string expectedResults = $"{description}: No Results";
            TotalStat _stat = new(description);

            for (int x = 0; x < gatherLoopCount; x++)
            {
                _stat.Gather(null); // stat only cares about a count
            }

            _stat.Reset();

            Assert.AreEqual(expectedResults, _stat.ToString());
        }
    }
}