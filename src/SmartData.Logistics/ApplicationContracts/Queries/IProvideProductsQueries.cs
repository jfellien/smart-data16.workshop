using System.Collections.Generic;

namespace ApplicationContracts.Queries
{
    public interface IProvideProductsQueries
    {
        IReadOnlyList<Product> All();
    }
}