using System;
using System.Text;

namespace Prototype_Pattern
{
    public partial class FoodOrder: Prototype
    {
        public string CustomerName { get; set; }
        public bool IsDelivery { get; set; }
        public string[] OrderContents { get; set; }
        public OrderInfo OrderInfo { get; set; }

        public FoodOrder(string customerName, bool isDelivery, string [] orderContents,OrderInfo orderInfo)
        {
            CustomerName = customerName;
            IsDelivery = isDelivery;
            OrderContents = orderContents;
            OrderInfo = orderInfo;
        }

        public override void Debug()
        {
            var sb = new StringBuilder()
                .AppendLine("-------------- Prototype Food Order --------------")
                .AppendLine($"Name: {CustomerName}")
                .AppendLine($"Delivery: {IsDelivery}")
                .AppendLine($"ID: {OrderInfo.Id}")
                .AppendLine($"Order Contents: {string.Join(",", OrderContents)}");

            Console.WriteLine(sb.ToString());
        }

        public override Prototype ShallowCopy()
        {
            return (Prototype)this.MemberwiseClone();
        }

        public override Prototype DeepCopy()
        {
            var foodOrder = (FoodOrder)this.MemberwiseClone();
            foodOrder.OrderInfo = new OrderInfo(this.OrderInfo.Id);

            return foodOrder;
        }
    }
}
