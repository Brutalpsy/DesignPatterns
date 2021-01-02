
using Abstract_Factory.Business;
using NUnit.Framework;
using System;

namespace Abstract_Factory.Tests
{
    public class ShoppingCartTests
    {
        [Test]
        public void FinalizedOrderWIthoutPurchaseProvider_ThrowsException()
        {
            var orderFactory = new StandardOrderFactory();
            var order = orderFactory.GetOrder();
            var cart = new ShoppingCart(order, null);
            Assert.Throws<NullReferenceException>(()=> cart.Finalize());
        }

        [Test]
        public void FinalizeOrderWithSwedenPurchaseProvider_GeneratesShippingLabel()
        {
            var orderFactory = new StandardOrderFactory();

            var order = orderFactory.GetOrder();

            var purchaseProviderFactory = new SwedenPurchaseProviderFactory();

            var cart = new ShoppingCart(order, purchaseProviderFactory);

            var label = cart.Finalize();

            Assert.IsNotNull(label);
        }
    }
}