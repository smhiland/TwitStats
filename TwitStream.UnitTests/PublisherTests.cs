using NUnit.Framework;
using TwitStream.Core;
using TwitStream.DTOs;
using System;
using System.Collections.Generic;

namespace TwitStream.UnitTests
{
    public class PublisherTests
    {
        private PublisherBuilder _builder;
        private ICredentials _credentials;
        private IClient _client;
        private IStream _stream;
        private IPublisher _publisher;

        [SetUp]
        public void Setup()
        {
            _client = new Client();
            _credentials = new Credentials()
            {
                Key = "any",
                Secret = "any",
                BearerToken = "any"
            };
            _stream = new SampleStream();
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("SomeFilter")]
        public void BuildPublisher_NonFilteredStream_Valid(string filter)
        {
            _builder = new PublisherBuilder(_credentials, filter);
            Assert.IsNotNull(_builder.BuildPublisher());
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("SomeFilter")]
        public void BuildPublisher_NonFilteredStream_InvalidClient(string filter)
        {
            _builder = new PublisherBuilder(null, filter);
            Assert.Throws<ArgumentNullException>(() => _builder.BuildPublisher());
        }

        [Test]
        public void StartAsync_Valid()
        {
            _stream.SetClient(_client.CreateClient(_credentials));
            _stream.CreateStream();
            _publisher = new Publisher(_stream);
            Assert.IsNotNull(_publisher.StartAsync());
        }

        [Test]
        [TestCaseSource("InvalidStreams")]
        public void StartAsync_InvalidStream(IStream stream)
        {
            _publisher = new Publisher(stream);
            Assert.Throws<ArgumentNullException>(() => _publisher.StartAsync());
        }

        [Test]
        [TestCaseSource("ValidStreams")]
        public void StartAsync_ValidStream(IStream stream)
        {
            _publisher = new Publisher(stream);
            Assert.IsNotNull(_publisher.StartAsync());
            // fails because of underlying _stream object
        }

        [Test]
        public void Publisher_Invalid()
        {
            Assert.Throws<ArgumentNullException>(() => new Publisher(null));
        }

        [Test]
        [TestCaseSource("ValidStreams")]
        public void Publisher_Valid(IStream stream)
        {
            _publisher = new Publisher(stream);
            Assert.Pass();
        }

        #region Case Sources
        public static IEnumerable<IStream> InvalidStreams
        {
            get
            {
                yield return new SampleStream();
                yield return new FilteredStream("SomeFilter");
            }
        }

        public static IEnumerable<IStream> ValidStreams
        {
            get
            {
                yield return ValidStream(null);
                yield return ValidStream("SomeFilter");
            }
        }

        public static IStream ValidStream(string filter)
        {
            Credentials credentials = new()
            {
                Key = "any",
                Secret = "any",
                BearerToken = "any"
            };
            StreamBuilder streamBuilder = new(credentials, filter);

            return streamBuilder.BuildStream();
        }
        #endregion
    }
}