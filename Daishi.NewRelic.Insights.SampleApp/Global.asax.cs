using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Daishi.NewRelic.Insights.SampleApp
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NewRelicInsightsClient.Instance.NewRelicInsightsMetadata.AccountID =
                "{New Relic Account ID}";
            NewRelicInsightsClient.Instance.NewRelicInsightsMetadata.APIKey =
                "{New Relic API key}";
            NewRelicInsightsClient.Instance.NewRelicInsightsMetadata.URI =
                new Uri("https://insights-collector.newrelic.com/v1/accounts");

            if (!NewRelicInsightsClient.Instance.HasStarted)
            {
                NewRelicInsightsClient.Instance.Initialise();
            }
        }
    }
}