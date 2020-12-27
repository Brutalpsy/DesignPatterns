using System;
using System.Collections.Generic;
using System.Linq;

namespace Builder.InventoryReportExample
{
    public class DailyReportBuilder : IFurnitureInventoryBuilder
    {
        private InventoryReport _report;
        private readonly IEnumerable<FurnitureItem> _items;

        public DailyReportBuilder(IEnumerable<FurnitureItem> items)
        {
            Reset();
            _items = items;
        }

        public void Reset()
        {
            _report = new InventoryReport();
        }

        public IFurnitureInventoryBuilder AddDimensions()
        {
            _report.DimensionsSection = string.Join(Environment.NewLine, _items.Select(product=> $"Product: {product.Name} \nPrice: {product.Price} \n"+
            $"Height: {product.Height} x Widrh {product.Width} -> Weight: {product.Weight}"));
            return this;
        }

        public IFurnitureInventoryBuilder AddLogistics(DateTime dateTime)
        {
            _report.LogisticsSection = $"Report generated on {dateTime}";
            return this;
        }

        public IFurnitureInventoryBuilder AddTitle()
        {
            _report.TitleSection = "----------- Daily Inventory Report ----------- \n\n ";
            return this;
        }

        public InventoryReport GetDailyReport()
        {
            var report = _report;
            Reset();

            return report;
        }
    }
}
