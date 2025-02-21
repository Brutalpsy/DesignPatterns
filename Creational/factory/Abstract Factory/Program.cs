﻿using Abstract_Factory.Business;
using Abstract_Factory.Business.Models.Commerce;
using Abstract_Factory.Business.Providers;
using System;

namespace Abstract_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Create Order
            Console.Write("Recipient Country: ");
            var recipientCountry = Console.ReadLine().Trim();

            Console.Write("Sender Country: ");
            var senderCountry = Console.ReadLine().Trim();

            Console.Write("Total Order Weight: ");
            var totalWeight = Convert.ToInt32(Console.ReadLine().Trim());

            var order = new Order
            {
                Recipient = new Address
                {
                    To = "Danijel",
                    Country = recipientCountry
                },

                Sender = new Address
                {
                    To = "Someone else",
                    Country = senderCountry
                },

                TotalWeight = totalWeight
            };

            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m), 1);
            order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m), 1);
            #endregion

            #region withoutProvider
            //IPurchaseProviderFactory purchaseProviderFactory;

            //if (order.Sender.Country == "Sweden")
            //{
            //    purchaseProviderFactory = new SwedenPurchaseProviderFactory();
            //}
            //else if (order.Sender.Country == "Australia")
            //{
            //    purchaseProviderFactory = new AustralianPurchaseProvicerFactory();
            //}
            //else
            //{
            //    throw new Exception("Sender country not registered");
            //}
            #endregion


            var purchaseProviderFactory = new PurchaseProviderFactoryProvider()
                ?.CreateFactoryFor(order.Sender.Country) ?? throw new NotSupportedException("Sender country not registered");


            var cart = new ShoppingCart(order, purchaseProviderFactory);

            var shippingLabel = cart.Finalize();

            Console.WriteLine(shippingLabel);
        }
    }
}
