using ApplicationContracts.Commands;
using ApplicationDomain.Warehouse;
using Fluent_CQRS;

namespace ApplicationDomain
{
    public class WarehouseCommands
    {
        private readonly Aggregates _aggregates;

        public WarehouseCommands(Aggregates aggregates)
        {
            _aggregates = aggregates;
        }

        public void Handle(AddProduct addProduct)
        {
            _aggregates
                .Provide<Shelf>()
                .With(addProduct)
                .Try(shelf => shelf.AddProduct(addProduct.Product));
        }
    }
}
