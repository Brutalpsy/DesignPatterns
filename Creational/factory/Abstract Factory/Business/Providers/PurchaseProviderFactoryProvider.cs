using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Abstract_Factory.Business.Providers
{
    public class PurchaseProviderFactoryProvider
    {
        private readonly IEnumerable<Type> _factories;

        public PurchaseProviderFactoryProvider()
        {
            _factories = Assembly
                .GetAssembly(typeof(PurchaseProviderFactoryProvider))
                .GetTypes()
                .Where(t => typeof(IPurchaseProviderFactory).IsAssignableFrom(t));
        }

        public IPurchaseProviderFactory CreateFactoryFor(string name)
        {
            var factory = _factories.FirstOrDefault(x => x.Name.ToLower().Contains(name.ToLower()));

            return factory == null
                ? null 
                : (IPurchaseProviderFactory)Activator.CreateInstance(factory);
        }
    }
}
