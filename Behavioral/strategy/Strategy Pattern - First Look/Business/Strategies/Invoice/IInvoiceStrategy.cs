using Strategy_Pattern___First_Look.Business.Models;

namespace Strategy_Pattern___First_Look.Business.Strategies.Invoice
{
    public interface IInvoiceStrategy
    {
        public void Generate(Order order);  
    }
}
