using NUnit.Framework;
using TwitStream.Core;
using TwitStream.DTOs;
using System;

namespace TwitStream.UnitTests.Core
{
    public class StreamBuilderTests
    {
        private StreamBuilder _builder;
        private ICredentials _credentials;

        [SetUp]
        public void Setup()
        {
            _credentials = new Credentials()
            {
                Key = "any",
                Secret = "any",
                BearerToken = "any"
            };
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("SomeFilter")]
        public void BuildStream_NonFilteredStream_Valid(string filter)
        {
            _builder = new StreamBuilder(_credentials, filter);
            Assert.IsNotNull(_builder.BuildStream());
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("SomeFilter")]
        public void BuildStream_InvalidClient(string filter)
        {
            _builder = new StreamBuilder(null, filter);
            Assert.Throws<ArgumentNullException>(() => _builder.BuildStream());
        }
    }
}