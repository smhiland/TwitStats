using NUnit.Framework;
using TwitStats.Stats;

namespace TwitStats.UnitTests.Stats
{
    public class AverageReceivedTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Average")]
        [TestCase("Average Received")]
        public void Stat_NewWithDescription(string description)
        {
            Assert.AreEqual(description, (new AverageReceived(description)).Description);
        }

        //[Test]
        //[TestCase("Average", 6, "Average: 6")]
        //[TestCase("Average Received", 6, "Average Received: 6")]
        //[TestCase("Total", 1, "Total: 1")]
        //[TestCase("Total", 1000, "Total: 1,000")]
        //[TestCase("Total", 1000000, "Total: 1,000,000")]
        //[TestCase("Total", 50, "Total: 50")]
        //[TestCase("Total", 0, "Total: 0")]
        //public void Stat_Gather(string description, int gatherLoopCount, string expectedResults)
        //{
        //    TotalStat _stat = new(description);

        //    for(int x = 0; x < gatherLoopCount; x++)
        //    {
        //        _stat.Gather(null); // stat only cares about a count
        //    }

        //    Assert.AreEqual(expectedResults, _stat.ToString());
        //}

        [Test]
        [TestCase("Average", 6)]
        [TestCase("Average Count", 3)]
        [TestCase("Average", 1)]
        [TestCase("Average", 1000)]
        [TestCase("Average", 1000000)]
        [TestCase("Average", 50)]
        [TestCase("Average", 0)]
        public void Stat_Reset(string description, int gatherLoopCount)
        {
            string expectedResults = $"{description}: No Results";
            AverageReceived _stat = new(description);

            for (int x = 0; x < gatherLoopCount; x++)
            {
                _stat.Gather(null);
            }

            _stat.Reset();

            Assert.AreEqual(expectedResults, _stat.ToString());
        }
    }
}