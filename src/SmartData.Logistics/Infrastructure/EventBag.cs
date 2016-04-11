using Jil;

namespace Infrastructure
{
    class EventBag
    {
        [JilDirective("id")]
        public string Id { get; set; }
        [JilDirective("eventtype")]
        public string EventType { get; set; }
        [JilDirective("timestamp")]
        public string Timestamp { get; set; }
        [JilDirective("payload")]
        public string Payload { get; set; }
    }
}