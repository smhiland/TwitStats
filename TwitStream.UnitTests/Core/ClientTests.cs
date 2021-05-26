using NUnit.Framework;
using System;
using TwitStream.Core;
using TwitStream.DTOs;

namespace TwitStream.UnitTests.Core
{
    public class ClientTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("", "", "")]
        [TestCase(null, null, null)]
        [TestCase(null, null, "")]
        [TestCase(null, "", "")]
        [TestCase("", null, null)]
        [TestCase("", "", null)]
        [TestCase(null, "", null)]
        [TestCase(null, null, "Something")]
        [TestCase(null, "Something", "Something")]
        [TestCase("Something", null, null)]
        [TestCase("Something", "Something", null)]
        [TestCase(null, "Something", null)]
        public void StreamFactory_Throws_ArgumentNullException(string key, string secret, string bearerToken)
        {
            ICredentials credentials = new Credentials()
            {
                Key = key,
                Secret = secret,
                BearerToken = bearerToken
            };
            Assert.Throws<ArgumentNullException>(() => (new Client()).CreateClient(credentials));
        }

        [Test]
        [TestCase("Key", "Secret", "BearerToken")]
        [TestCase("AnyKey", "AnySecret", "AnyBearerToken")]
        public void StreamFactory_Valid(string key, string secret, string bearerToken)
        {
            ICredentials credentials = new Credentials()
            {
                Key = key,
                Secret = secret,
                BearerToken = bearerToken
            };
            Assert.IsNotNull((new Client()).CreateClient(credentials));
        }
    }
}