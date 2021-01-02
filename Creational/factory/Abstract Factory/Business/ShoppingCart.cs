using Abstract_Factory.Business.Models.Commerce;
using Abstract_Factory.Business.Models.Shipping;

namespace Abstract_Factory.Business
{
    public class ShoppingCart
    {
        private readonly Order _order;
        private readonly IPurchaseProviderFactory _purchaseProviderFactory;

        public ShoppingCart(Order order, IPurchaseProviderFactory purchaseProviderFactory)
        {
           _order = order;
            _purchaseProviderFactory = purchaseProviderFactory;
        }

        public string Finalize()
        {
            var shippingProvider = _purchaseProviderFactory.CreateShippingProvider(_order);
            var invoice = _purchaseProviderFactory.CreateInvoice(_order);
            var summary = _purchaseProviderFactory.CreateSummary(_order);

            // send invoice..
            summary.Send();


            _order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(_order);
        }
    }
}
