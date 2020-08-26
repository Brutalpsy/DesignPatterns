using Castle.DynamicProxy.Generators;
using MyShop.Domain.Models;
using MyShop.Infrastructure.Lazy.Ghosts;
using MyShop.Infrastructure.Lazy.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyShop.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(ShoppingContext context) : base(context)
        {
        }

        public override Customer Get(Guid id)
        {
            var customerId = context.Customers.Where(c => c.CustomerId == id)
                .Select(c => c.CustomerId).Single();

            return new GhostCustomer(() => base.Get(id)) {
                CustomerId = customerId
            };

        }
        public override IEnumerable<Customer> GetAll()
        {
            return base.GetAll().Select(MapToProxy);
        }
        public override Customer Update(Customer entity)
        {
            var customer = context.Customers.Single(c => c.CustomerId == entity.CustomerId);
            customer.CustomerId = entity.CustomerId;
            customer.Name = entity.Name;
            customer.PostalCode = entity.PostalCode;
            customer.ShippingAddress = entity.ShippingAddress;
            customer.Country = entity.Country;

            return base.Update(customer);
        }

        private CustomerProxy MapToProxy(Customer customer)
        {
            return new CustomerProxy
            {
                ShippingAddress = customer.ShippingAddress,
                City = customer.City,
                Country = customer.Country,
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                PostalCode = customer.PostalCode,
                ProfilePicture = customer.ProfilePicture
            };
        }
    }
}
