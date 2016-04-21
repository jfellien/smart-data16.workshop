using System.Collections.Generic;

namespace ApplicationContracts.Queries
{
    public interface IProvideProductsQueries
    {
        IReadOnlyList<Product> All();
        void Add(string id, string name, double price);
    }
}