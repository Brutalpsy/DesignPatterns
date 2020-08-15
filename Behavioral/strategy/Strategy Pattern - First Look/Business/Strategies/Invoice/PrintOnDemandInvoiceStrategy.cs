using Newtonsoft.Json;
using Strategy_Pattern___First_Look.Business.Models;
using System;
using System.Net.Http;

namespace Strategy_Pattern___First_Look.Business.Strategies.Invoice
{
    public class PrintOnDemandInvoiceStrategy : IInvoiceStrategy
    {
        public void Generate(Order order)
        {
            using(var client = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(order);
                client.BaseAddress = new Uri("https://www.bejsAdress.com");
                client.PostAsync("/print-on-demand", new StringContent(content));
            }
        }
    }
}
