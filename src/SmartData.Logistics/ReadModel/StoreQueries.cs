using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using ApplicationContracts;
using ApplicationContracts.Queries;
using Infrastructure;
using Jil;

namespace ReadModel
{
    public class StoreQueries : IProvideStoresQueries
    {
        private readonly string _baseUrl;

        public StoreQueries()
        {
            _baseUrl = ConfigurationManager.AppSettings["DatabaseBaseUri"];
        }

        public Store For(string postZip)
        {
            var getRequest = RestClient.AsJsonGetRequest(
                new Uri(_baseUrl + "/api/store-by-postzip/" + postZip));

            var getResponse = getRequest.Execute();

            var stores = JSON.Deserialize<List<Store>>(getResponse);

            return stores.First();
        }
    }
}