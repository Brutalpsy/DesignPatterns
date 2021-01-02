using System.Text;

namespace Abstract_Factory.Business.Models.Commerce.Invoice
{
    public class NoVatInvoice : IInvoice
    {
        public byte[] GenerateInvoice()
        {
            return Encoding
                  .Default
                  .GetBytes("Hellow from No VAT Invoice");
        }
    }
}
