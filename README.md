<a href="https://insidethecpu.com/2016/07/22/new-relic-insights-net-client/">![Image of insidethecpu](https://insidethecpu.files.wordpress.com/2016/06/daishi-systems-icon-with-text-really-tiny-with-photo1.png)</a>
# New Relic Insights .NET Client
## A lightweight C# client for New Relic Insights	
[![Join the chat at https://gitter.im/daishisystems/Daishi.NewRelic](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/daishisystems/Daishi.NewRelic?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![Build status](https://ci.appveyor.com/api/projects/status/ly3h4f406u5332n3?svg=true)](https://ci.appveyor.com/project/daishisystems/daishi-newrelic)
[![NuGet](https://img.shields.io/badge/nuget-v1.0.2-blue.svg)](https://www.nuget.org/packages/Daishi.NewRelic)

* *Upload New Relic Insights events on-demand*
* *Upload in batches, as a scheduled task*
* *Minimal CPU usage (1 thread)*
* *Proxy-aware*

#Upload a Single Event
##Create the Event
Create a class that implements NewRelicInsightsEvent:
```cs
public class CustomNewRelicInsightsEvent : NewRelicInsightsEvent
{
    [JilDirective(Name = "name")]
    public string Name { get; set; }

    [JilDirective(Name = "count")]
    public int Count { get; set; }

    [JilDirective(Name = "unixTimeStamp")]
    public int UnixTimeStamp
        => (int) DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

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
```

Note: NewRelic.NET leverages Jil for serialisation. Though JilDirective attributes are not required for custom properties, the EventType property requires the specified JilDirective.

##Initialise New Relic Metadata
```cs
NewRelicInsightsClient.Instance.NewRelicInsightsMetadata.AccountID = "{New Relic Account ID}";
NewRelicInsightsClient.Instance.NewRelicInsightsMetadata.APIKey = "{New Relic API key}";
NewRelicInsightsClient.Instance.NewRelicInsightsMetadata.URI = 
	new Uri("https://insights-collector.newrelic.com/v1/accounts");
```
##Upload the Event
![Event Upload Animation](https://dl.dropboxusercontent.com/u/26042707/New%20Relic%20Event%20Upload.gif)
```cs
var customNewRelicInsightsEvent = new CustomNewRelicInsightsEvent
{
	Name = "TEST",
   	Count = id,
   	EventType = "Test"
};
```    
###Synchronously
```cs
NewRelicInsightsClient.Instance.UploadEvents(
	new NewRelicInsightsEvent[]
	{ 
		customNewRelicInsightsEvent 
	}, 
	new HttpClientFactory());
```
###Asynchronously
```cs
NewRelicInsightsClient.Instance.UploadEventsAsync(
	new NewRelicInsightsEvent[]
	{ 
		customNewRelicInsightsEvent 
	}, 
	new HttpClientFactory());
```
#Upload Events in Batches
![Batch Event Upload Animation](https://dl.dropboxusercontent.com/u/26042707/New%20Relic%20Batch%20Upload.gif)
##Start the Event Cache
```cs
if (!NewRelicInsightsClient.Instance.HasStarted)
{
    NewRelicInsightsClient.Instance.Initialise();
}
```
##Add Events to the Cache
```cs
NewRelicInsightsClient.Instance.AddNewRelicInsightEvent(customNewRelicInsightsEvent);
```
###Event Upload Frequency
Batch-upload occurs every minute, by default, unless a custom frequency is specified. The following example sets the upload-frequency to 10 minutes:
```cs
NewRelicInsightsClient.Instance.RecurringTaskInterval = 10;
```
###Proxy Server
The following example indicates that a proxy should be leveraged when invoking HTTP requests to New Relic:
```cs
NewRelicInsightsClient.Instance.NewRelicInsightsMetadata.UseWebProxy = true;
NewRelicInsightsClient.Instance.NewRelicInsightsMetadata.WebProxy = new WebProxy(“127.0.0.1:8080”);
```
###Custom HTTP Timeout
Outbound HTTP requests to NewRelic are restricted to a specific timeout (5 seconds) as follows:
```cs
NewRelicInsightsClient.Instance.NewRelicInsightsMetadata.UseNonDefaultTimeout = true;
NewRelicInsightsClient.Instance.NewRelicInsightsMetadata.NonDefaultTimeout = new TimeSpan(0,0,5);
```
Otherwise, the default C# HttpClient-timeout applies.
###Restricting Batch Upload Size
The default batch-upload size is 1,000 events. That is, a batch consisting of no more that 1,000 events will be uploaded upon each cache upload-cycle. The following example indicates that the entire cache should be emptied upon every upload-cycle:
```cs
NewRelicInsightsClient.Instance.NewRelicInsightsMetadata.CacheUploadLimit = int.MaxValue;
```
#Contact the Developer
<a href="http://insidethecpu.com/feed/">![RSS](https://dl.dropboxusercontent.com/u/26042707/rss.png)</a><a href="https://twitter.com/daishisystems">![Twitter](https://dl.dropboxusercontent.com/u/26042707/twitter.png)</a><a href="https://www.linkedin.com/in/daishisystems">![LinkedIn](https://dl.dropboxusercontent.com/u/26042707/linkedin.png)</a><a href="https://plus.google.com/102806071104797194504/posts">![Google+](https://dl.dropboxusercontent.com/u/26042707/g.png)</a><a href="https://www.youtube.com/user/daishisystems">![YouTube](https://dl.dropboxusercontent.com/u/26042707/youtube.png)</a>
