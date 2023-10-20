namespace MedicalWasteCollectApp
{
    public class Truck
    {
        public static string CompanyName = "RM";

        private List<int> loads = new List<int>();

        public Truck(string regNumber)
        {
            this.RegNumber = regNumber;
            this.MaxLoad = MaxLoads;
        }

        public Truck(string regNumber, int maxLoad)
        {
            this.RegNumber = regNumber;
            this.MaxLoad = maxLoad;
        }

        public string RegNumber { get; private set; }
        public int MaxLoad { get; private set; }

        public int MaxLoads
        {
            get
            {
                return 1000;
            }
        }

        public int LoadsSum
        {
            get
            {
                return this.loads.Sum();
            }
        }

        public void AddWaste(int load)
        {
            if (load > 0 && load <= this.MaxLoad)
            {
                this.loads.Add(load);
            }
            else
            {
                Console.WriteLine("Wrong input value");
            }
        }

        public void AddWaste(string load)
        {
            if (int.TryParse(load, out int result))
            {
                this.AddWaste(result);
            }
            else
            {
                Console.WriteLine("Input is not intiger");
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

        public void UnloadWaste()
        {
            this.loads.Add(-(this.loads.Sum()));
        }

        public Statistics GetStatistics()
        {
            var statistics = new Statistics();
            int counter = 0;
            statistics.Average = 0;
            statistics.Max = int.MinValue;
            statistics.Min = int.MaxValue;

            foreach (var load in this.loads)
            {
                if (load > 0)
                {
                    statistics.Max = Math.Max(statistics.Max, load);
                    statistics.Min = Math.Min(statistics.Min, load);
                    statistics.Average += load;
                    counter++;
                }
            }

            statistics.Average /= counter;

            return statistics;
        }
    }
}
