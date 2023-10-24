using System.Net.Http.Headers;

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

            switch (statistics.Average)
            {
                case var average when average >= (95/100 * this.MaxLoad):
                    statistics.AverageLetter = 'A';
                    break;
                case var average when average >= (80 / 100 * this.MaxLoad):
                    statistics.AverageLetter = 'B';
                    break;
                case var average when average >= (60 / 100 * this.MaxLoad):
                    statistics.AverageLetter = 'C';
                    break;
                case var average when average >= (40 / 100 * this.MaxLoad):
                    statistics.AverageLetter = 'D';
                    break;
                case var average when average >= (20 / 100 * this.MaxLoad):
                    statistics.AverageLetter = 'E';
                    break;
                default:
                    statistics.AverageLetter = 'F';
                    break;
            }

            return statistics;
        }
    }
}
