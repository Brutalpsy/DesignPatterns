using Strategy_Pattern___First_Look.Business.Models;
using Strategy_Pattern___First_Look.Business.Strategies.Invoice;
using Strategy_Pattern___First_Look.Business.Strategies.SalesTax;
using Strategy_Pattern___First_Look.Business.Strategies.Shipping;
using System;

namespace Strategy_Pattern___First_Look
{
    class Program
    {
        static void Main(string[] args)
        {
            #region UserInput

            Console.WriteLine("Please select an origin country");
            var origin = Console.ReadLine().Trim();

            Console.WriteLine("Please select a destination country:");
            var destination = Console.ReadLine().Trim();

            Console.WriteLine("Chose one of the following shipping providers");
            Console.WriteLine("1. Swedish Postal Service");
            Console.WriteLine("2. DHL");
            Console.WriteLine("3. Fedex");
            Console.WriteLine("Select shipping provider: ");
            var provider = Convert.ToInt32(Console.ReadLine().Trim());

            Console.WriteLine("Choose one of the follwoign invoice delivery options");
            Console.WriteLine("1. File (the only thing that works!)");
            Console.WriteLine("2. Email");
            Console.WriteLine("3. Mail");
            Console.WriteLine("Select invoice delivery options");
            var invoiceOption = Convert.ToInt32(Console.ReadLine().Trim());
            #endregion

            var order = new Order
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = origin,
                    DestinationCountry = destination
                },
                InvoiceStrategy = GetInvoiceStrategyFor(invoiceOption),
                ShippingStrategy = GetShippingStrategyFor(provider),
                SalesTaxStrategy = GetSalesTaxStrategyFor(origin)
            };

            order.LineItems.Add(
                new Item("CSHARPT_SMORGASBORD", "C# smorgasboard", 100m, ItemType.Literature), 1);

            order.LineItems.Add(
                new Item("Consulting", "Building a website", 100m, ItemType.Service), 1);

            order.SelectedPayments.Add(
                new Payment()
                {
                    PaymentProvider = PaymentProvider.Invoice
                });

            Console.WriteLine(order.GetTax(new SwedenSalesTaxStrategy()));
            order.FinalizeOrder();
        }

        private static IInvoiceStrategy GetInvoiceStrategyFor(int invoiceOption)
        {
            switch (invoiceOption)
            {
                case 1: return new FileInvoiceStrategy();
                case 2: return new EmailInvoiceStrategy();
                case 3: return new PrintOnDemandInvoiceStrategy();
                default: throw new Exception("Unsupported invoice ");
            }
        }

        private static IShippingStrategy GetShippingStrategyFor(int provider)
        {
            switch (provider)
            {
                case 1: return new SwedishPostalServiceShippingStrategy();
                case 2: return new DhlShippingStrategy();
                case 3: return new FedExShipppingStrategy();
                default: throw new Exception("Unsupported shipping method");
            }
        }

        private static ISalesTaxStrategy GetSalesTaxStrategyFor(string origin)
        {
            if (origin.ToLowerInvariant() == "sweden") 
            {
                return new SwedenSalesTaxStrategy();
            }
            else if (origin.ToLowerInvariant() == "usa")
            {
                return new USAStateSalesTaxStrategy();
            }
            else
            {
                throw new Exception("Unsupported region");
            }
        }
    }
}
