using Abstract_Factory.Business.Models.Commerce;
using Abstract_Factory.Business.Models.Commerce.Invoice;
using Abstract_Factory.Business.Models.Commerce.Summary;
using Abstract_Factory.Business.Models.Shipping;

namespace Abstract_Factory.Business
{
    public interface IPurchaseProviderFactory
    {
        ShippingProvider CreateShippingProvider(Order order);
        IInvoice CreateInvoice(Order order);
        ISummary CreateSummary(Order summary);
    }
}
