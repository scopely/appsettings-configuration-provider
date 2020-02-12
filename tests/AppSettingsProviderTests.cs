using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Scopely.Configuration;

namespace Tests
{
    [TestFixture]
    public class AppSettingsProviderTests
    {
        IConfiguration _config;

        [OneTimeSetUp]
        public void Setup()
        {
            _config = new ConfigurationBuilder()
                .AddAppSettingsFile("AppSettings.config", false)
                .Build();
        }

        [Test]
        public void Cleared_key_should_not_exist()
            => Assert.AreEqual(null, _config["clearedKey"]);

        [Test]
        public void Removed_key_should_not_exist()
            => Assert.AreEqual(null, _config["removedKey"]);

        [Test]
        public void Overwritten_key_should_be_good()
            => Assert.AreEqual("good", _config["overwrittenKey"]);

        [Test]
        public void Added_key_should_be_good()
            => Assert.AreEqual("good", _config["addedKey"]);
    }
}