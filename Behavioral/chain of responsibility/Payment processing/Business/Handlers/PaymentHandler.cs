using Payment_processing.Business.Exceptions;
using Payment_processing.Business.Models;
using System;
using System.Collections.Generic;

namespace Payment_processing.Business.Handlers.PaymentHandlers
{
    public class PaymentHandler
    {
        private readonly ICollection<IReceiver<Order>> _receivers;
        public PaymentHandler(params IReceiver<Order>[] receivers)
        {
            _receivers = receivers;
        }
        public void Handle(Order order)
        {
            foreach (var receiver in _receivers)
            {
                Console.WriteLine($"Running: {receiver.GetType().Name}");
                if (order.AmountDue > 0)
                {
                    receiver.Handle(order);
                }
                else
                {
                    break;
                }
            }

            if (order.AmountDue > 0)
            {
                throw new InsufficientPaymentException();
            }
            else
            {
                order.ShippingStatus = ShippingStatus.ReadyForShippment;
            }

        }

        public void SetNext(IReceiver<Order> next)
        {
            _receivers.Add(next);
        }
    }
}
