namespace MedicalWasteCollectApp
{
    public class Truck
    {
        public static string CompanyName = "RM";

        private List<int> loads = new List<int>();

        public Truck(string regNumber)
        {
            this.RegNumber = regNumber;
        }

        public string RegNumber { get; private set; }

        public int LoadsSum
        {
            get
            {
                return this.loads.Sum();
            }
        }

        public void AddWaste(int load)
        {
            this.loads.Add(load);
        }

        public void UnloadWaste()
        {
            this.loads.Add(-(this.loads.Sum()));
        }
    }
}
