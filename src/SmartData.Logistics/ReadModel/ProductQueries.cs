using System;
using System.Collections.Generic;
using System.Configuration;
using ApplicationContracts;
using ApplicationContracts.Queries;
using Infrastructure;
using Jil;

namespace ReadModel
{
    public class ProductQueries : IProvideProductsQueries
    {
        private readonly string _baseUrl;

        public ProductQueries()
        {
            _baseUrl = ConfigurationManager.AppSettings["DatabaseBaseUri"];
        }

        public IReadOnlyList<Product> All()
        {
            var getRequest = RestClient.AsJsonGetRequest(
                new Uri(_baseUrl + "/api/products"));

            var getResponse = getRequest.Execute();

            var products = JSON.Deserialize<List<Product>>(getResponse);

            return products;
        }

        public void Add(string id, string name, double price)
        {
            var postRequest = RestClient.AsJsonPostRequest(
                new Uri(_baseUrl + "/api/product"));

            postRequest.Execute(JSON.Serialize(new Product
            {
                Id = id,
                Name = name,
                Price = price
            }));
        }
    }
}
