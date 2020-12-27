using System;

namespace Builder.InventoryReportExample
{
    public class InventoryBuildDirector
    {
        private readonly IFurnitureInventoryBuilder _furnitureInventoryBuilder;
        public InventoryBuildDirector(IFurnitureInventoryBuilder furnitureInventoryBuilder)
        {
            _furnitureInventoryBuilder = furnitureInventoryBuilder;
        }

        public void BuildCompleteReport()
        {
            _furnitureInventoryBuilder
                .AddTitle()
                .AddDimensions()
                .AddLogistics(DateTime.Now);
        }
    }
}
