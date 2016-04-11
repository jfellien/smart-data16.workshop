using System.Collections.Generic;
using ApplicationContracts;
using ApplicationContracts.Queries;

namespace ReadModel
{
    public class DeliveryQueries : IProvideDeliveryQueries
    {
        public IReadOnlyList<DeliverySuggestion> SuggestionsFor(DeliveryRequest request)
        {
            // Bitte selber ausfüllen :-)

            return null;
        }
    }
}
