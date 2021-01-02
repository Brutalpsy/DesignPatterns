using Abstract_Factory.Business.Models.Commerce;
using Abstract_Factory.Business.Models.Commerce.Invoice;
using Abstract_Factory.Business.Models.Commerce.Summary;
using Abstract_Factory.Business.Models.Shipping;
using Abstract_Factory.Business.Models.Shipping.Factories;

namespace Abstract_Factory.Business
{
    public class AustralianPurchaseProvicerFactory : IPurchaseProviderFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            return new GTSInvoice();
        }

        public ShippingProvider CreateShippingProvider(Order order)
        {
            var shippingProviderFactory = new StandardShippingProviderFactory();
            return shippingProviderFactory.CreateShippingProvider(order.Sender.Country);
        }

        public ISummary CreateSummary(Order summary)
        {
            return new CSVSummary();
        }
    }
}
