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
        ///     <see cref="DefaultCacheUploadLimitIsAssignedIfOneIsNotProvided" />
        ///     ensures that a default
        ///     <see cref="NewRelicInsightsClient.CacheUploadLimit" />
        ///     is assigned, if one is not provided.
        /// </summary>
        [TestMethod]
        public void DefaultCacheUploadLimitIsAssignedIfOneIsNotProvided()
        {
            Assert.AreEqual(1000, NewRelicInsightsClient.Instance.CacheUploadLimit);
        }

        /// <summary>
        ///     <see cref="CustomRecurringTaskNameIsAssignedIfProvided" /> ensures that a
        ///     custom <see cref="NewRelicInsightsClient.RecurringTaskName" /> is assigned,
        ///     when provided.
        /// </summary>
        [TestMethod]
        public void CustomRecurringTaskNameIsAssignedIfProvided()
        {
            NewRelicInsightsClient.Instance.RecurringTaskName = "Custom";

            Assert.AreEqual("Custom", NewRelicInsightsClient.Instance.RecurringTaskName);
        }

        /// <summary>
        ///     <see cref="CustomRecurringTaskIntervalIsAssignedIfProvided" />
        ///     ensures that a custom
        ///     <see cref="NewRelicInsightsClient.RecurringTaskInterval" />
        ///     is assigned, when provided.
        /// </summary>
        [TestMethod]
        public void CustomRecurringTaskIntervalIsAssignedIfProvided()
        {
            NewRelicInsightsClient.Instance.RecurringTaskInterval = 5;

            Assert.AreEqual(5, NewRelicInsightsClient.Instance.RecurringTaskInterval);
        }

        /// <summary>
        ///     <see cref="CustomCacheUploadLimitIsAssignedIfProvided" />
        ///     ensures that a custom
        ///     <see cref="NewRelicInsightsClient.CacheUploadLimit" />
        ///     is assigned, when provided.
        /// </summary>
        [TestMethod]
        public void CustomCacheUploadLimitIsAssignedIfProvided()
        {
            NewRelicInsightsClient.Instance.CacheUploadLimit = 2000;

            Assert.AreEqual(2000, NewRelicInsightsClient.Instance.CacheUploadLimit);
        }

        /// <summary>
        ///     <see cref="DefaultCacheUploadLimitIsAssignedIfInvalid" />
        ///     ensures that a default
        ///     <see cref="NewRelicInsightsClient.CacheUploadLimit" />
        ///     is assigned, if the specified value is invalid.
        /// </summary>
        [TestMethod]
        public void DefaultCacheUploadLimitIsAssignedIfInvalid()
        {
            NewRelicInsightsClient.Instance.CacheUploadLimit = -1;

            Assert.AreEqual(1000, NewRelicInsightsClient.Instance.CacheUploadLimit);
        }
    }
}