using Abstract_Factory.Business.Models.Commerce;
using Abstract_Factory.Business.Models.Commerce.Invoice;
using Abstract_Factory.Business.Models.Commerce.Summary;
using Abstract_Factory.Business.Models.Shipping;
using Abstract_Factory.Business.Models.Shipping.Factories;

namespace Abstract_Factory.Business
{
    public class SwedenPurchaseProviderFactory : IPurchaseProviderFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            if(order.Recipient.Country != order.Sender.Country)
            {
                return new NoVatInvoice();
            }

            return new VATInvoice();
        }

        public ShippingProvider CreateShippingProvider(Order order)
        {
            ShippingProviderFactory shippingProviderFactory;

            if(order.Sender.Country != order.Recipient.Country)
            {
                shippingProviderFactory = new GlobalExpressShippingProviderFactory();
            }
            else
            {
                shippingProviderFactory = new StandardShippingProviderFactory();
            }


            return shippingProviderFactory.CreateShippingProvider(order.Sender.Country);
        }

        public ISummary CreateSummary(Order summary)
        {
            return new EmailSummary();
        }
    }
}
