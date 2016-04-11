using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationContracts;
using ApplicationContracts.Queries;
using Infrastructure;
using Jil;

namespace ReadModel
{
    public class StoreQueries : IProvideStoresQueries
    {
        public Store For(string postZip)
        {
            var getRequest = RestClient.AsJsonGetRequest(
                new Uri("http://192.168.178.20:3000/api/store-by-postzip/" + postZip));

            var getResponse = getRequest.Execute();

            var stores = JSON.Deserialize<List<Store>>(getResponse);

            return stores.First();
        }
    }
}