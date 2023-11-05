namespace MedicalWasteCollectApp
{
    public abstract class TruckBase : ITruck
    {
        public delegate void WasteAddedDelegate(object sender, EventArgs args);

        public abstract event WasteAddedDelegate WasteAdded;

        public TruckBase(string vin, string regNumber)
        {
            this.Vin = vin;
            this.RegNumber = regNumber;
        }

        public TruckBase(string vin, string regNumber, int maxLoad)
        {
            this.Vin = vin;
            this.RegNumber = regNumber;
            this.MaxLoad = maxLoad;
        }

        public string Vin { get; private set; }

        public string RegNumber { get; private set; }

        public int MaxLoad { get; private set; }

        public abstract void AddWaste(int load);

        public abstract void AddWaste(string load);

        public abstract void AddWaste(float load);

        public abstract void AddWaste(double load);

        public abstract void UnloadWaste();

        public abstract Statistics GetStatistics();
    }
}
