using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Daishi.NewRelic.Tests
{
    /// <summary>
    ///     <see cref="NewRelicInsightsClientTests" /> ensures that logic pertaining to
    ///     <see cref="NewRelicInsightsClient" /> instances is executed correctly.
    /// </summary>
    [TestClass]
    public class NewRelicInsightsClientTests
    {
        /// <summary>
        ///     <see cref="NewRelicInsightsEventIsAddedToCache" /> ensures that instances
        ///     of <see cref="NewRelicInsightsEvent" /> are added to
        ///     <see cref="NewRelicInsightsClient.NewRelicInsightsEvents" />.
        /// </summary>
        [TestMethod]
        public void NewRelicInsightsEventIsAddedToCache()
        {
            var dummyNewRelicInsightsEvent = new DummyNewRelicInsightsEvent();

            NewRelicInsightsClient.Instance.AddNewRelicInsightEvent(dummyNewRelicInsightsEvent);

            Assert.AreEqual(1, NewRelicInsightsClient.Instance.NewRelicInsightsEvents.Count);
        }
    }
}