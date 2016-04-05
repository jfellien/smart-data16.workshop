using System;
using System.Collections.Generic;
using ApplicationContracts;
using ApplicationContracts.Queries;

namespace MockedRepositories
{
    public class MockedDeliveryQueries : IProvideDeliveryQueries
    {
        public IReadOnlyList<DeliverySuggestion> SuggestionsFor(DeliveryRequest request)
        {
            return new List<DeliverySuggestion>
            {
                new DeliverySuggestion(DateTime.Now)
            };
        }
    }
}