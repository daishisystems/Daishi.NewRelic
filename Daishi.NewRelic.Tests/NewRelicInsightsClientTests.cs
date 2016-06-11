using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Daishi.NewRelic.Tests
{
    /// <summary>
    ///     <see cref="NewRelicInsightsClientTests" /> ensures that events are
    ///     successfully prepared for publish to New Relic Insights.
    /// </summary>
    [TestClass]
    public class NewRelicInsightsClientTests
    {
        /// <summary>
        ///     <see cref="InvalidAccountIDThrowsException" /> ensures that a
        ///     <see cref="NewRelicInsightsMetadataException" /> is thrown when an instance
        ///     of <see cref="NewRelicInsightsMetadata" />, that contains an invalid
        ///     <see cref="NewRelicInsightsMetadata.AccountID" />, is leveraged to publish
        ///     a <see cref="NewRelicInsightsEvent" /> instance.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NewRelicInsightsMetadataException))]
        public void InvalidAccountIDThrowsException()
        {
            var newRelicInsightsMetadata = new NewRelicInsightsMetadata();

            NewRelicInsightsClient.PublishNewRelicInsightsEvent(null, newRelicInsightsMetadata);
        }
    }
}