using NUnit.Framework;
using System;
using TwitStream.Core;

namespace TwitStream.UnitTests.Core
{
    public class StreamFactoryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("", typeof(SampleStream))]
        [TestCase(" ", typeof(SampleStream))]
        [TestCase(null, typeof(SampleStream))]
        [TestCase("SomeFilter", typeof(FilteredStream))]
        [TestCase("Some other Filter", typeof(FilteredStream))]
        public void StreamFactory_Valid(string filter, Type streamType)
        {
            Assert.AreEqual(streamType, StreamFactory.CreateStream(filter).GetType());
        }

        [Test]
        [TestCase("", typeof(FilteredStream))]
        [TestCase(" ", typeof(FilteredStream))]
        [TestCase(null, typeof(FilteredStream))]
        [TestCase("SomeFilter", typeof(SampleStream))]
        [TestCase("Some other Filter", typeof(SampleStream))]
        public void StreamFactory_Invalid(string filter, Type streamType)
        {
            Assert.AreNotEqual(streamType, StreamFactory.CreateStream(filter).GetType());
        }
    }
}