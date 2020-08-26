using MyShop.Domain.Models;
using MyShop.Infrastructure.Repositories;

namespace MyShop.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Customer> CustomerRepository { get; }
        IRepository<Order> OrderRepository { get; }
        IRepository<Product> ProductRepository { get; }
        void SaveChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private  ShoppingContext _shoppingContext;
        public UnitOfWork(ShoppingContext shoppingContext)
        {
            _shoppingContext = shoppingContext;
        }

        private IRepository<Customer> customerRepository;
        public IRepository<Customer> CustomerRepository
        {
            get
            {
                if (customerRepository == null)
                {
                    customerRepository = new CustomerRepository(_shoppingContext);
                }

                return customerRepository;
            }
        }

        private IRepository<Order> orderRepository;
        public IRepository<Order> OrderRepository
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new OrderRepository(_shoppingContext);
                }

                return orderRepository;
            }
        }

        private IRepository<Product> productRepository;
        public IRepository<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(_shoppingContext);
                }

                return productRepository;
            }
        }
        public void SaveChanges()
        {
            _shoppingContext.SaveChanges();
        }
    }
}
