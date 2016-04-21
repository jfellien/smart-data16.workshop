using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Fluent_CQRS;
using Jil;

namespace Infrastructure
{
    public class OrientDbEventStore : IStoreAndRetrieveEvents
    {
        private readonly string _baseUrl;

        public OrientDbEventStore()
        {
            _baseUrl = ConfigurationManager.AppSettings["DatabaseBaseUri"];
        }

        public void StoreFor<TAggregate>(string aggegateId, IAmAnEventMessage eventMessage) where TAggregate : Aggregate
        {
            var serializedEvent = JSON.SerializeDynamic(eventMessage);

            var eventBag = new EventBag
            {
                Id = aggegateId,
                EventType = eventMessage.GetType().Name,
                Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Payload = serializedEvent
            };

            var serializedEventBag = JSON.Serialize(eventBag);

            var postEvent = RestClient.AsJsonPostRequest(new Uri(_baseUrl + "/api/event"));
            postEvent.Execute(serializedEventBag);
        }

        public IEnumerable<IAmAnEventMessage> RetrieveFor(string aggregateId)
        {
            var getEvents = RestClient.AsJsonGetRequest(new Uri(_baseUrl + "/api/events-for/" + aggregateId));
            var serializedEventBags = getEvents.Execute();

            var eventBags = JSON.Deserialize<List<EventBag>>(serializedEventBags);

            return eventBags.Select(eventBag =>
                JSON.Deserialize(eventBag.Payload, Type.GetType(eventBag.EventType)) as IAmAnEventMessage);
        }

        public IEnumerable<IAmAnEventMessage> RetrieveFor<TAggregate>(string aggregateId) where TAggregate : Aggregate
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAmAnEventMessage> RetrieveFor<TAggregate>() where TAggregate : Aggregate
        {
            throw new NotImplementedException();
        }
    }
}