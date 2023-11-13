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
    public class Txts
    {
        public static void MainMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("Co zamierzasz zrobić?");
            Console.WriteLine("");
            Console.WriteLine("1 - Załadunek");
            Console.WriteLine("2 - Rozładunek");
            Console.WriteLine("3 - Wyświetla statystyki");
            Console.WriteLine("Q - Wyjście");
            Console.Write("Więc? :");
        }

        public static void InLoad()
        {
            Console.WriteLine("");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Jesteś w załadunek.");
            Console.WriteLine("");
        }

        public static void ConfirmUnload()
        {
            Console.WriteLine("");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Jesteś w rozładunek.");
            Console.Write("Potwierdź rozładunek wprowadzając dowolną wartość i/lub naciśnij ENTER (powrót do wczesniejszego menu bez rozładunku - q):");
        }

        public static void UnloadConfirmation()
        {
            Console.WriteLine("");
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Pojazd rozładowany.");
        }

        public static void CantUnload()
        {
            Console.WriteLine("");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Pojazd jest pusty, nie ma nic do rozładowania.");
        }

        public static void PrintWelcome()
        {
            Console.WriteLine("");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("         Kończymy na dziś.          ");
            Console.WriteLine("------------------------------------");
        }
    }
}
