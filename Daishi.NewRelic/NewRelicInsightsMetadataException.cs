using System;

namespace Daishi.NewRelic
{
    /// <summary>
    ///     <see cref="NewRelicInsightsMetadataException" /> is thrown if an instance
    ///     of <see cref="NewRelicInsightsMetadata" />, that contains invalid, or
    ///     omitted properties, is used to establish a connection to New Relic
    ///     Insights.
    /// </summary>
    public class NewRelicInsightsMetadataException : Exception
    {
        public NewRelicInsightsMetadataException()
        {
        }

        public NewRelicInsightsMetadataException(string message) : base(message)
        {
        }

        public NewRelicInsightsMetadataException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}