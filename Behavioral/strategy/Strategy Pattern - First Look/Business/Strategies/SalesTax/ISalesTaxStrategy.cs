using Strategy_Pattern___First_Look.Business.Models;

namespace Strategy_Pattern___First_Look.Business.Strategies.SalesTax
{
    public interface ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order);
    }
}
