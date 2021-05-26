using NUnit.Framework;
using TwitStream.Core;
using TwitStream.DTOs;
using System;

namespace TwitStream.UnitTests
{
    public class PublisherBuilderTests
    {
        private PublisherBuilder _builder;
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
        public void BuildPublisher_Stream_Valid(string filter)
        {
            _builder = new PublisherBuilder(_credentials, filter);
            Assert.IsNotNull(_builder.BuildPublisher());
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("SomeFilter")]
        public void BuildPublisher_Stream_InvalidClient(string filter)
        {
            _builder = new PublisherBuilder(null, filter);
            Assert.Throws<ArgumentNullException>(() => _builder.BuildPublisher());
        }
    }
}