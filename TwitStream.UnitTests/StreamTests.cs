using NUnit.Framework;
using TwitStream.Core;
using TwitStream.DTOs;
using System;

namespace TwitStream.UnitTests
{
    public class StreamTests
    {
        private IClient _client;
        private ICredentials _credentials;
        private IStream _stream;

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
        public void SetClient_ClientValid()
        {
            Assert.IsNotNull(_stream.SetClient(_client.CreateClient(_credentials)));
        }

        [Test]
        public void SetClient_ClientInvalid()
        {
            Assert.Throws<ArgumentNullException>(() => _stream.SetClient(null));
        }

        [Test]
        public void CreateStream_Valid()
        {
            _stream.SetClient(_client.CreateClient(_credentials));
            Assert.IsNotNull(_stream.CreateStream());
        }

        [Test]
        public void CreateStream_InvalidClient()
        {
            Assert.Throws<ArgumentNullException>(() => _stream.CreateStream());
        }

        [Test]
        public void StartAsync_Valid()
        {
            _stream.SetClient(_client.CreateClient(_credentials));
            _stream.CreateStream();
            Assert.IsNotNull(_stream.StartAsync());
        }

        [Test]
        public void StartAsync_InvalidClient_InvalidStream()
        {
            Assert.Throws<ArgumentNullException>(() => _stream.StartAsync());
        }

        [Test]
        public void StartAsync_ValidClient_InvalidStream()
        {
            _stream.SetClient(_client.CreateClient(_credentials));
            Assert.Throws<ArgumentNullException>(() => _stream.StartAsync());
        }
    }
}