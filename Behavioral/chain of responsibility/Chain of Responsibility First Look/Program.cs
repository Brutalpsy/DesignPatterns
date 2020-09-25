using Chain_of_Responsibility_First_Look.Business;
using System;
using System.Globalization;

namespace Chain_of_Responsibility_First_Look
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User("Danijel", "8701010XXXXX", new RegionInfo("RS"), new DateTimeOffset(1989, 05, 28, 00, 00, 00, TimeSpan.FromHours(10)));

            var processor = new UserProcessor();
            var result = processor.Register(user);

            Console.WriteLine(result);
        }
    }
}
