using Strategy_Pattern___First_Look.Business.Models;
using System.Net.Http;

namespace Strategy_Pattern___First_Look.Business.Strategies.Shipping
{
    public class SwedishPostalServiceShippingStrategy: IShippingStrategy
    {
        public void Ship(Order order)
        {
            using var client = new HttpClient();
            //ImplementSwedishPostalService Integration

            System.Console.WriteLine("Order is shippied with SwedishPostalService");
        }
    }
}
