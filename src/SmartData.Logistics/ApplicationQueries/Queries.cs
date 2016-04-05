using ApplicationContracts.Queries;

namespace ApplicationQueries
{
    public class Queries
    {
        public Queries(
            IProvideProductsQueries productsQueries, 
            IProvideStoresQueries storesQueries,
            IProvideDeliveryQueries deliveryQueries)
        {
            Products = productsQueries;
            Stores = storesQueries;
            Deliveries = deliveryQueries;
        }

        public IProvideProductsQueries Products { get; private set; }
        public IProvideStoresQueries Stores { get; private set; }
        public IProvideDeliveryQueries Deliveries { get; private set; }
    }
}