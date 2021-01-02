using System.Text;

namespace Abstract_Factory.Business.Models.Commerce.Invoice
{
    public class VATInvoice : IInvoice
    {
        public byte[] GenerateInvoice()
        {
            return Encoding
                  .Default
                  .GetBytes("Hellow from VAT Invoice");
        }
    }
}
