using Strategy_Pattern___First_Look.Business.Models;
using System.Net.Http;

namespace Strategy_Pattern___First_Look.Business.Strategies.Shipping
{
    public class FedExShipppingStrategy: IShippingStrategy
    {
        public void Ship(Order order)
        {
            using var client = new HttpClient();
            //Implement FedEx Shipping Integration

            System.Console.WriteLine("Order is shippied with FedEx");
        }
    }
}
