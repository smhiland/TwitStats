using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TwitStats.Core;
using TwitStats.Helpers;

namespace TwitStats.UnitTests.Helpers
{
    public class StatHelperTests
    {
        IEnumerable<IDataPoint> dataPoints;
        CaseData caseData;

        [SetUp]
        public void Setup()
        {
            caseData = TestHelper.CreateCaseData_1();
            dataPoints = caseData.DataPoints;
        }

        [Test]
        public void ContainsUrl_Count()
        {
            int count = StatHelper.ContainsUrl(dataPoints).Count();
            Assert.AreEqual(caseData.TotalUrlCount, count);
        }

        [Test]
        public void GetUrl_Count()
        {
            int count = StatHelper.GetUrls(dataPoints).Count();
            Assert.AreEqual(caseData.TotalUrlCount, count);
        }

        [Test]
        public void ContainsHashtag_Count()
        {
            int count = StatHelper.GetHashtags(dataPoints).Count();
            Assert.AreEqual(caseData.TotalHashtagCount, count);
        }

        [Test]
        public void GetDomains_Count()
        {
            int count = StatHelper.GetDomains(dataPoints).Count();
            Assert.AreEqual(caseData.TotalUrlCount, count);
        }

        [Test]
        [TestCase(null, "")]
        [TestCase("", "")]
        [TestCase("http://www.google.com", "www.google.com")]
        [TestCase("http://google.com", "google.com")]
        [TestCase("google.com", "")]
        [TestCase("not a url", "")]
        public void GetDomain_Value(string url, string expectedDomain)
        {
            string domain = StatHelper.GetDomain(url);
            Assert.AreEqual(expectedDomain, domain);
        }
    }
}