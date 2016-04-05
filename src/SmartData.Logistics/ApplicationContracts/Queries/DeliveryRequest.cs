namespace ApplicationContracts.Queries
{
    public class DeliveryRequest
    {
        public DeliveryRequest(int productId, string postZip)
        {
            ProductId = productId;
            PostZip = postZip;
        }

        public int ProductId { get; private set; }
        public string PostZip { get; private set; }
    }
}