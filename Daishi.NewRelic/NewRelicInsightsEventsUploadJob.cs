using System;
using System.Web.Hosting;
using FluentScheduler;

namespace Daishi.NewRelic
{
    /// <summary>
    ///     <see cref="NewRelicInsightsEventsUploadJob" /> is a recurring task that
    ///     continously uploads <see cref="NewRelicInsightsEvent" />
    ///     instances to New Relic Insights.
    /// </summary>
    internal class NewRelicInsightsEventsUploadJob : IJob, IRegisteredObject
    {
        private readonly object _lock = new object();

        private bool _shuttingDown;

        /// <summary>
        ///     <see cref="Execute" /> invokes a process that uploads cached
        ///     <see cref="NewRelicInsightsEvent" />
        ///     instances to New Relic Insights.
        /// </summary>
        public void Execute()
        {
            lock (_lock)
            {
                if (_shuttingDown)
                    return;

                try
                {

                }
                catch (Exception)
                {
                    // ToDo: swallow error in lieu of a fallback solution, should New Relic Insights be offline.
                }
            }
        }

        /// <summary>Requests a registered object to unregister.</summary>
        /// <param name="immediate">
        ///     true to indicate the registered object should
        ///     unregister from the hosting environment before returning; otherwise, false.
        /// </param>
        public void Stop(bool immediate)
        {
            lock (_lock)
            {
                _shuttingDown = true;
            }

            HostingEnvironment.UnregisterObject(this);
        }
    }
}