using System;
using System.Collections.Generic;

namespace Builder.InventoryReportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<FurnitureItem>
            {
                new FurnitureItem
                { 
                    Name = "Sectional Couch", Height = 55.5, Price =22.4, Weight=78.6, Width = 35.0
                },
                new FurnitureItem 
                {
                     Name= "Nightstand", Height = 25.0, Price =12.4, Weight=20.0, Width = 10.0
                },
                new FurnitureItem
                {
                    Name= "Dining Table", Height = 105.0, Price =35.4, Weight=100.6, Width = 55.5
                }
            };

            var inventoryBuilder = new DailyReportBuilder(items);

            //var director = new InventoryBuildDirector(inventoryBuilder);
            //director.BuildCompleteReport();
            //var directorReport = inventoryBuilder.GetDailyReport();
            //Console.WriteLine(directorReport.Debug());


            var fluetReport = inventoryBuilder
                .AddTitle()
                .AddDimensions()
                .AddLogistics(DateTime.Now)
                .GetDailyReport();

            Console.WriteLine(fluetReport.Debug());
        }
    }
}
