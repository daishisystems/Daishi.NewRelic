using System.Collections.Generic;
using System.Web.Http;

namespace Daishi.NewRelic.Insights.SampleApp.Controllers
{
    public class EventsController : ApiController
    {
        // GET: api/Events
        public IEnumerable<string> Get()
        {
            return new[] {"value1", "value2"};
        }

        // GET: api/Events/5
        public string Get(int id)
        {
            var customNewRelicInsightsEvent = new CustomNewRelicInsightsEvent
            {
                Name = "TEST",
                Count = id,
                EventType = "AegisTest"
            };

            NewRelicInsightsClient.Instance.AddNewRelicInsightEvent(customNewRelicInsightsEvent);

            return id + " added.";
        }

        // POST: api/Events
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Events/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Events/5
        public void Delete(int id)
        {
        }
    }
}