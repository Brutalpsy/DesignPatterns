using Strategy_Pattern___First_Look.Business.Models;
using System.Net;
using System.Net.Mail;

namespace Strategy_Pattern___First_Look.Business.Strategies.Invoice
{
    public class EmailInvoiceStrategy : InvoiceStrategy
    {
        public override void Generate(Order order)
        {
            var body = GenerateTextInvoice(order);

            using(SmtpClient client = new SmtpClient("smtp.sendgrid.net", 587))
            {
                NetworkCredential credentials = new NetworkCredential("lol", "no");
                client.Credentials = credentials;

                MailMessage mail = new MailMessage("yo@yo.com", "yo1@yo1.com")
                {
                    Subject = "We've created an invoice for your order",
                    Body = body
                };

                client.Send(mail);
            }
        }
    }
}
