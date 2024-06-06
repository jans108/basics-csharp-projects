using WiredBrainCoffee.DataProcessor.Model;

namespace WiredBrainCoffee.DataProcessor.Processing;

public class MachineDataProcessorTests
{
    [Fact]
    public void ShouldSaveCountPerCoffeType()
    {
        //Arrange
        var machineDataProcessor = new MachineDataProcessor();
        var items = new[]
        {
            new MachineDataItem("Cappuccino",new DateTime(2022,10,27,8,0,0)),
            new MachineDataItem("Cappuccino",new DateTime(2022,10,27,9,0,0)),
            new MachineDataItem("Espresso",new DateTime(2022,10,27,10,0,0))
        };

        //Act
        machineDataProcessor.ProcessItems(items);

        //Assert

    }
}
