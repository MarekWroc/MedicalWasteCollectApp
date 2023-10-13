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

        [Test]
        public void WhenGetStatisticsCalled_SouldRetuenCorrectAverage()
        {
            // arrange
            var truck = new Truck("SK256HT");
            truck.AddWaste(22);
            truck.AddWaste(16);
            truck.AddWaste(33);
            truck.UnloadWaste();
            truck.AddWaste(7);
            truck.AddWaste(56);
            // act
            var statistics = truck.GetStatistics();
            // assert
            Assert.AreEqual(Math.Round(26.8, 1), Math.Round(statistics.Average, 1));
        }

        [Test]
        public void WhenGetStatisticsCalled_SouldRetuenCorrectMin()
        {
            // arrange
            var truck = new Truck("SK256HT");
            truck.AddWaste(5);
            truck.AddWaste(92);
            truck.AddWaste(14);
            truck.UnloadWaste();
            truck.AddWaste(6);
            truck.AddWaste(36);
            // act
            var statistics = truck.GetStatistics();
            // assert
            Assert.AreEqual(5, statistics.Min);
        }

        [Test]
        public void WhenGetStatisticsCalled_SouldRetuenCorrectMax()
        {
            // arrange
            var truck = new Truck("SK256HT");
            truck.AddWaste(2);
            truck.AddWaste(55);
            truck.AddWaste(18);
            truck.UnloadWaste();
            truck.AddWaste(43);
            truck.AddWaste(6);
            truck.UnloadWaste();
            // act
            var statistics = truck.GetStatistics();
            // assert
            Assert.AreEqual(55, statistics.Max);
        }

    }
}