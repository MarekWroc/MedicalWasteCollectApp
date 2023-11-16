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

        public void AddWaste(string load)
        {
            if (int.TryParse(load, out int result))
            {
                this.AddWaste(result);
            }
            else
            {
                throw new Exception("Podana wartość nie jest liczbą.");
            }
        }

        public void AddWaste(float load)
        {
            int result = (int)Math.Ceiling(load);
            this.AddWaste(result);
        }

        public void AddWaste(double load)
        {
            int result = (int)Math.Ceiling(load);
            this.AddWaste(result);
        }

        public abstract void UnloadWaste();

        public abstract Statistics GetStatistics();
    }
}
