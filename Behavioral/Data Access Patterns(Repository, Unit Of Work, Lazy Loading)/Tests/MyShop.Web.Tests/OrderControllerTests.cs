using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyShop.Domain.Models;
using MyShop.Infrastructure;
using MyShop.Infrastructure.Repositories;
using MyShop.Infrastructure.UnitOfWork;
using MyShop.Web.Controllers;
using MyShop.Web.Models;
using System;

namespace MyShop.Web.Tests
{
    [TestClass]
    public class OrderControllerTests
    {
        [TestMethod]
        public void CanCreateOrderWithCorrectModel()
        {
            var unitOfWork = new Mock<IUnitOfWork>();

            var context = new Mock<ShoppingContext>();
            var orderRepo = new Mock<OrderRepository>(context.Object);
            var customerRepo = new Mock<CustomerRepository>(context.Object);

            unitOfWork.Setup(x => x.OrderRepository).Returns(orderRepo.Object);
            unitOfWork.Setup(x => x.CustomerRepository).Returns(customerRepo.Object);

            var orderController = new OrderController(unitOfWork.Object);
            var customer = new CustomerModel()
            {
                Name = "Danijel",
                ShippingAddress = "Test adress",
                City = "Novi Sad",
            };

            var createOrderModel = new CreateOrderModel()
            {
                Customer = customer,
                LineItems = new[]
                {
                    new LineItemModel{ProductId = Guid.NewGuid(), Quantity=2},
                    new LineItemModel{ProductId = Guid.NewGuid(), Quantity=12},
                }
            };

            orderController.Create(createOrderModel);
            orderRepo.Verify(x => x.Add(It.IsAny<Order>()), Times.AtMostOnce());
            unitOfWork.Verify(x => x.SaveChanges(), Times.AtMostOnce());
        }
    }
}
