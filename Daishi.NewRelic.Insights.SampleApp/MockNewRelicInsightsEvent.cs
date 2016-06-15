using Jil;

namespace Daishi.NewRelic.Insights.SampleApp
{
    internal class MockNewRelicInsightsEvent : NewRelicInsightsEvent
    {
        [JilDirective(Name = "name")]
        public string Name { get; set; }

        public int Count { get; set; }

        /// <summary>
        ///     EventType is the New Relic Insights Event Grouping. It determines the
        ///     database to which the event will persist.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         <see cref="NewRelicInsightsEvent.EventType" /><c>must</c> be serialised
        ///         in Camel case, in order to be correctly interpreted by New Relic
        ///         Insights.
        ///     </para>
        ///     <para>
        ///         Apply the following attribute to the
        ///         <see cref="NewRelicInsightsEvent.EventType" />
        ///         property in your implementation:
        ///     </para>
        ///     <para>
        ///         <c>[JilDirective(Name = "eventType")]</c>
        ///     </para>
        /// </remarks>
        [JilDirective(Name = "eventType")]
        public string EventType { get; set; }
    }
}