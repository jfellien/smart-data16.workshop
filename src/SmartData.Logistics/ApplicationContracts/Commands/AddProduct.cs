using Fluent_CQRS;

namespace ApplicationContracts.Commands
{
    public class AddProduct : IAmACommandMessage
    {
        public string Id { get; set; }
        public Product Product { get; set; }
    }
}