using Fluent_CQRS;

namespace ApplicationContracts.Events
{
    public class ProductAdded : IAmAnEventMessage
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public double CurrentPrice { get; set; }
    }
}