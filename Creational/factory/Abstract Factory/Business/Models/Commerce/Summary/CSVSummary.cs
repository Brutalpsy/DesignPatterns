namespace Abstract_Factory.Business.Models.Commerce.Summary
{
    public class CSVSummary : ISummary
    {
        public string CreateOrderSummary(Order order)
        {
            return "This is an csv summary";
        }

        public void Send()
        {
            System.Console.WriteLine("Sending CSV Summary");

        }
    }
}
