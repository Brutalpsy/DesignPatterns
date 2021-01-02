using Factory_Method.Business.Models.Commerce;
using Factory_Method.Business.Models.Shipping;
using Factory_Method.Business.Models.Shipping.Factories;

namespace Factory_Method.Business
{
    public class ShoppingCart
    {
        private readonly Order _order;
        private readonly ShippingProviderFactory _shippingProviderFactory;

        public ShoppingCart(Order order, ShippingProviderFactory shippingProviderFactory)
        {
            _order = order;
            _shippingProviderFactory = shippingProviderFactory;
        }

        public string Finalize()
        {
            var shippingProvider = _shippingProviderFactory.GetShippingProvider(_order.Sender.Country);

            _order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(_order);
        }
    }
}
