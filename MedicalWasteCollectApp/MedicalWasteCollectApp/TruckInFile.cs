using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MedicalWasteCollectApp
{
    public class TruckInFile : TruckBase
    {
        public static string CompanyName = "RM";
        public static string Depot = "PL";

        private const string fileName = "truck.txt";

        public override event WasteAddedDelegate WasteAdded;

        public TruckInFile(string vin, string regNumber)
            : base(vin, regNumber)
        {
            this.MaxLoad = 1000;
        }

        public TruckInFile(string vin, string regNumber, int maxLoad)
            : base(vin, regNumber, maxLoad)
        {
        }

        public int MaxLoad { get; private set; }

        public string FileName
        {
            get
            {
                string filename = fileName; 
                return filename;
            }
        }

        public int LoadsSum
        {
            get
            {
                var loadsSum = 0;
                if (File.Exists(fileName))
                {
                    using (var reader = File.OpenText(fileName))
                    {
                        var line = reader.ReadLine();
                        while (line != null)
                        {
                            var load = int.Parse(line);
                            loadsSum += load;
                            line = reader.ReadLine();
                        }
                    }
                }
                return loadsSum;
            }
        }

        public override void AddWaste(int load)
        {
            if (load > 0 && load <= (this.MaxLoad - this.LoadsSum))
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(load);
                }

                if (WasteAdded != null)
                {
                    WasteAdded(this, new EventArgs());
                }
            }
            else if (load > 0 && load > (this.MaxLoad - this.LoadsSum) && (this.MaxLoad - this.LoadsSum) != 0)
            {
                var availibeLoadSpace = (this.MaxLoad - this.LoadsSum);

                Console.WriteLine($"Przyjęto część ładunku, tj. {availibeLoadSpace} z {load}.");
                Console.WriteLine($"Pozostaje nieodebrane: {(load - availibeLoadSpace)}.");

                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(availibeLoadSpace);
                }
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
            var loadsToUnload = -(this.LoadsSum);
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine(loadsToUnload);
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var waste = int.Parse(line);
                        statistics.AddWaste(waste);
                        line = reader.ReadLine();
                    }
                }
            
            return statistics;
        }

    }
}
