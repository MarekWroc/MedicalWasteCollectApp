namespace MedicalWasteCollectApp
{
    public class Statistics
    {
        public float Average
        {
            get
            {
                return this.Sum / this.Count;
            }
        }

        public char FillingAsLetter
        {
            get
            {
                switch (this.Filling)
                {
                    case var sum when sum >= 950:
                        return 'A';
                    case var sum when sum >= 800:
                        return 'B';
                    case var sum when sum >= 600:
                        return 'C';
                    case var sum when sum >= 400:
                        return 'D';
                    case var sum when sum >= 200:
                        return 'E';
                    default:
                        return '-';
                }
            }
        }

        public int Min { get; private set; }

        public int Max { get; private set; }

        public int Sum { get; private set; }

        public int Filling { get; private set; }

        public int Count { get; private set; }

        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Min = int.MaxValue;
            this.Max = int.MinValue;
        }

        public void AddWaste(int waste)
        {
            this.Filling += waste;

            if (waste > 0)
            {
                this.Count++;
                this.Sum += waste;
                this.Min = Math.Min(waste, this.Min);
                this.Max = Math.Max(waste, this.Max);
            }
        }
    }
}