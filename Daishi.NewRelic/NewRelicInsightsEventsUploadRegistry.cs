using FluentScheduler;

namespace Daishi.NewRelic
{
    /// <summary>
    ///     <see cref="NewRelicInsightsEventsUploadRegistry" /> is a Fluent Scheduler
    ///     directive that initialises a recurring task that continously uploads
    ///     <see cref="NewRelicInsightsEvent" />
    ///     instances to New Relic Insights.
    /// </summary>
    internal class NewRelicInsightsEventsUploadRegistry : Registry
    {
        public NewRelicInsightsEventsUploadRegistry()
        {
            Schedule<NewRelicInsightsEventsUploadJob>()
                .WithName(NewRelicInsightsClient.Instance.RecurringTaskName)
                .ToRunNow()
                .AndEvery(NewRelicInsightsClient.Instance.RecurringTaskInterval)
                .Minutes();
        }
    }
}