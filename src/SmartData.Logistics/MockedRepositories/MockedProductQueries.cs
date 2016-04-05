using System;
using System.Collections.Generic;
using ApplicationContracts;
using ApplicationContracts.Queries;

namespace MockedRepositories
{
    public class MockedProductQueries : IProvideProductsQueries
    {
        public IReadOnlyList<Product> All()
        {
            return new List<Product>
            {
                new Product(1, "Stuhl", 25.99),
                new Product(2, "Tisch", 200.80),
                new Product(3, "Sofa", 555)
            };
        }
    }
}