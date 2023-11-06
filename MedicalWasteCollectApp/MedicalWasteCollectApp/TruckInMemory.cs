namespace MedicalWasteCollectApp
{
    public class TruckInMemory : TruckBase
    {
        public override event WasteAddedDelegate WasteAdded;

        public static string CompanyName = "RM";
        public static string Depot = "PL";

        private List<int> loads = new List<int>();

        public TruckInMemory(string vin, string regNumber)
            : base(vin, regNumber)
        {
            this.MaxLoad = 1000;
        }

        public TruckInMemory(string vin, string regNumber, int maxLoad)
            : base(vin, regNumber, maxLoad)
        {
        }

        public int MaxLoad { get; private set; }

        public int LoadsSum
        {
            get
            {
                return this.loads.Sum();
            }
        }

        public override void AddWaste(int load)
        {
            if (load > 0 && load <= (this.MaxLoad - this.LoadsSum))
            {
                this.loads.Add(load);

                if (WasteAdded != null)
                {
                    WasteAdded(this, new EventArgs());
                }
            }
            else if (load > 0 && load > (this.MaxLoad - this.LoadsSum) && (this.MaxLoad - this.LoadsSum) != 0)
            {
                Console.WriteLine($"Przyjęto część ładunku, tj. {(this.MaxLoad - this.LoadsSum)} z {load}.");
                Console.WriteLine($"Pozostaje nieodebrane: {(load - (this.MaxLoad - this.LoadsSum))}.");
                this.loads.Add((this.MaxLoad - this.LoadsSum));
            }
            else if (load > 0 && load > (this.MaxLoad - this.LoadsSum) && (this.MaxLoad - this.LoadsSum) == 0)
            {
                throw new Exception("Pojazd w pełni załadowany.");
            }
            else
            {
                throw new Exception("Nieprawidłowa wartość.");
            }
        }

        public override void AddWaste(string load)
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

        public override void AddWaste(float load)
        {
            int result = (int)Math.Ceiling(load);
            this.AddWaste(result);
        }

        public override void AddWaste(double load)
        {
            int result = (int)Math.Ceiling(load);
            this.AddWaste(result);
        }

        public override void UnloadWaste()
        {
            this.loads.Add(-(this.loads.Sum()));
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            if (this.loads.Count > 0)
            {
                foreach (var load in this.loads)
                {
                    statistics.AddWaste(load);
                }
            }
            else
            {
                Console.WriteLine("Brak danych do stworzenia statystyk");
            }
            return statistics;
        }
    }
}
