using System;
using System.Collections.Generic;

namespace Daishi.NewRelic.Insights.SampleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var newRelicInsightsEvents =
                new List<MockNewRelicInsightsEvent>
                {
                    new MockNewRelicInsightsEvent
                    {
                        EventType = "AegisTest",
                        Name = "Random 4",
                        Count = 100
                    },
                    new MockNewRelicInsightsEvent
                    {
                        EventType = "AegisTest",
                        Name = "Random 5",
                        Count = 50
                    }
                };

            var newRelicInsightsMetadata = new NewRelicInsightsMetadata
            {
                AccountID = "646832",
                APIKey = "bx97bcRZ0nVQSb80O5GcVtyYREbQLNSz",
                URI = new Uri(
                    "https://insights-collector.newrelic.com/v1/accounts")
            };

            NewRelicInsightsClient.UploadEvents(newRelicInsightsEvents,
                new HttpClientFactory(), newRelicInsightsMetadata);

            Console.ReadLine();
        }
    }
}