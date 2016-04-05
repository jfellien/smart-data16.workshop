using System.IO;
using ApplicationContracts;
using ApplicationContracts.Queries;

namespace MockedRepositories
{
    public class MockedStoresQueries : IProvideStoresQueries
    {
        public Store For(string postZip)
        {
            switch (postZip)
            {
                case "12345":
                    return new Store(1, "Berlin");
                case "23456":
                    return new Store(2, "Hannover");
                default:
                    return new Store(0, "Unbekannt");
            }
        }
    }
}