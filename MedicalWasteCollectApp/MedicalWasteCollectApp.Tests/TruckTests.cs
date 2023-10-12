namespace MedicalWasteCollectApp.Tests
{
    public class Tests
    {
        [Test]
        public void WhenTruckCollectsLoads_SouldShowSum()
        {
            // arrange
            var truck = new Truck("SK9453V");
            truck.AddWaste(19);
            truck.AddWaste(52);
            truck.AddWaste(7);
            // act
            var sum = truck.LoadsSum;
            // assert
            Assert.AreEqual(78, sum);
        }

        [Test]
        public void WhenTruckWasUnload_SouldShowZero()
        {
            // arrange
            var truck = new Truck("SK9453V");
            truck.AddWaste(19);
            truck.AddWaste(52);
            truck.AddWaste(7);
            truck.UnloadWaste();
            // act
            var loads = truck.LoadsSum;
            // assert
            Assert.AreEqual(0, loads);
        }
    }
}