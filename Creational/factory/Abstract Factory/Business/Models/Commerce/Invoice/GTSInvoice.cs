using System.Text;

namespace Abstract_Factory.Business.Models.Commerce.Invoice
{
    public class GTSInvoice : IInvoice
    {
        public byte[] GenerateInvoice()
        {
            return Encoding
                  .Default
                  .GetBytes("Hellow from GTS Invoice");
        }
    }
}
