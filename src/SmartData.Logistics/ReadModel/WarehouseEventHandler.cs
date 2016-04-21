using System.Collections.Generic;
using System.Linq;
using ApplicationContracts.Events;
using ApplicationQueries;
using Fluent_CQRS;
using Fluent_CQRS.Extensions;

namespace ReadModel
{
    public class WarehouseEventHandler : IHandleEvents
    {
        private Queries _queries;

        public WarehouseEventHandler(Queries queries)
        {
            _queries = queries;
        }
        public void Receive(IEnumerable<IAmAnEventMessage> events)
        {
            events.ToList().ForEach(message => message.HandleMeWith(this));
        }

        void Handle(ProductAdded message)
        {
            _queries.Products.Add(message.Id, message.ProductName, message.CurrentPrice);
        }
    }
}
