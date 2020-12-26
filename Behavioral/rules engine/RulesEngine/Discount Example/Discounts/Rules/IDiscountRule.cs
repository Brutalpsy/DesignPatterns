namespace RulesEngine.Discounts
{
    public interface IDiscountRule
    {
        public decimal CalculateDiscount(Customer customer, decimal currentDiscount);
    }
}
