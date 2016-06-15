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

        /// <summary>
        ///     <see cref="DefaultRecurringTaskNameIsAssignedIfOneIsNotProvided" /> ensures
        ///     that a default <see cref="NewRelicInsightsClient.RecurringTaskName" /> is
        ///     assigned, if one is not provided.
        /// </summary>
        [TestMethod]
        public void DefaultRecurringTaskNameIsAssignedIfOneIsNotProvided()
        {
            Assert.AreEqual("GetBlackListJob", NewRelicInsightsClient.Instance.RecurringTaskName);
        }

        /// <summary>
        ///     <see cref="DefaultRecurringTaskIntervalIsAssignedIfOneIsNotProvided" />
        ///     ensures that a default
        ///     <see cref="NewRelicInsightsClient.RecurringTaskInterval" />
        ///     is assigned, if one is not provided.
        /// </summary>
        [TestMethod]
        public void DefaultRecurringTaskIntervalIsAssignedIfOneIsNotProvided()
        {
            Assert.AreEqual(1, NewRelicInsightsClient.Instance.RecurringTaskInterval);
        }

        /// <summary>
        ///     <see cref="CustomRecurringTaskNameIsAssignedIfOneIsNotProvided" /> ensures
        ///     that a custom <see cref="NewRelicInsightsClient.RecurringTaskName" /> is
        ///     assigned, when provided.
        /// </summary>
        [TestMethod]
        public void CustomRecurringTaskNameIsAssignedIfOneIsNotProvided()
        {
            NewRelicInsightsClient.Instance.RecurringTaskName = "Custom";

            Assert.AreEqual("Custom", NewRelicInsightsClient.Instance.RecurringTaskName);
        }

        /// <summary>
        ///     <see cref="CustomRecurringTaskIntervalIsAssignedIfOneIsNotProvided" />
        ///     ensures that a custom
        ///     <see cref="NewRelicInsightsClient.RecurringTaskInterval" />
        ///     is assigned, when provided.
        /// </summary>
        [TestMethod]
        public void CustomRecurringTaskIntervalIsAssignedIfOneIsNotProvided()
        {
            NewRelicInsightsClient.Instance.RecurringTaskInterval = 5;

            Assert.AreEqual(5, NewRelicInsightsClient.Instance.RecurringTaskInterval);
        }
    }
}