using System;
using System.Collections.Generic;
using ApplicationContracts;
using ApplicationContracts.Queries;
using Infrastructure;
using Jil;

namespace ReadModel
{
    public class ProductQueries : IProvideProductsQueries
    {
        public IReadOnlyList<Product> All()
        {

            var getRequest = RestClient.AsJsonGetRequest(
                new Uri("http://192.168.178.20:3000/api/products"));

            var getResponse = getRequest.Execute();

            var products = JSON.Deserialize<List<Product>>(getResponse);

            return products;
        }
    }
}
