using System.Collections.Generic;
using ApplicationContracts;
using ApplicationContracts.Events;
using Fluent_CQRS;

namespace ApplicationDomain.Warehouse
{
    public class Shelf : Aggregate
    {
        public Shelf(string id, IEnumerable<IAmAnEventMessage> history) : base(id, history)
        {
        }

        public void AddProduct(Product product)
        {
            Changes.Add(new ProductAdded
            {
                Id = Id,
                ProductName = product.Name,
                CurrentPrice = product.Price
            });
        }
    }
}