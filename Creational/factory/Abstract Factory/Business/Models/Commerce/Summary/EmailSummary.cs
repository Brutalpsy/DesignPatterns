namespace Abstract_Factory.Business.Models.Commerce.Summary
{
    public class EmailSummary : ISummary
    {
        public string CreateOrderSummary(Order order)
        {
            return "This is an email summary";
        }

        public void Send()
        {
            System.Console.WriteLine("Sending Email Summary");
        }
    }

}
