using MyShop.Domain.Models;
using MyShop.Infrastructure.Lazy.Proxies;
using System;

namespace MyShop.Infrastructure.Lazy.Ghosts
{
    enum LoadStatus { GHOST, LOADING, LOADED }
    public class GhostCustomer : CustomerProxy
    {
        private LoadStatus status;
        public bool IsGhost => status == LoadStatus.GHOST;
        public bool IsLoaded => status == LoadStatus.LOADED;

        private Func<Customer> _load { get; }

        public GhostCustomer(Func<Customer> load) : base()
        {
            _load = load;
            status = LoadStatus.GHOST;
        }

        public override string Name
        {
            get
            {
                Load();
                return base.Name;
            }
            set
            {
                Load();
                base.Name = value;
            }
        }

        public void Load()
        {
            if (IsGhost)
            {
                status = LoadStatus.LOADING;
                var customer = _load();
                base.Name = customer.Name;
                base.ShippingAddress = customer.ShippingAddress;
                base.PostalCode = customer.PostalCode;
                base.ProfilePicture = customer.ProfilePicture;
                base.City = customer.City;
                base.Country = customer.Country;
                base.CustomerId = customer.CustomerId;

                status = LoadStatus.LOADED;
            }
        }
    }
}
