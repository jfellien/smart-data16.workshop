using System.Collections.Generic;

namespace ApplicationContracts.Queries
{
    public interface IProvideDeliveryQueries
    {
        IReadOnlyList<DeliverySuggestion> SuggestionsFor(DeliveryRequest request);
    }
}