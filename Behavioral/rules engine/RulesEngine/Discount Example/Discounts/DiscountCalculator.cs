using System;
using System.Linq;

namespace RulesEngine.Discounts
{
    public class DiscountCalculator
    {
        public decimal CalculateDiscountPercentage(Customer customer)
        {

            var ruleType = typeof(IDiscountRule);
            var rules = GetType()
                .Assembly
                .GetTypes()
                .Where(type => ruleType.IsAssignableFrom(type) && !type.IsInterface)
                .OrderBy(type => type.CustomAttributes.Any(x => x.AttributeType == typeof(LastRuleAttribute)))
                .Select(type => Activator.CreateInstance(type) as IDiscountRule);

            var engine = new DiscountRuleEngine(rules);

            return engine.CalculateDiscountPercentage(customer);
        }
    }
}
