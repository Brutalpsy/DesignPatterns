using Strategy_Pattern___First_Look.Business.Models;

namespace Strategy_Pattern___First_Look.Business.Strategies.Shipping
{
    public interface IShippingStrategy
    {
        void Ship(Order order);
    }
}
