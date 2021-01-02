using Factory_Method.Business.Models.Commerce;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factory_Method.Business.Models.Shipping
{
    public class GlobalExpressShippingProvider : ShippingProvider
    {
        public override string GenerateShippingLabelFor(Order order)
        {
            return "GLOBAL-EXPRESS";
        }
    }
}
