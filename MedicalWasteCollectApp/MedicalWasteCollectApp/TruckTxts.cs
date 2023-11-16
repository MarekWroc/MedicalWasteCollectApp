namespace MedicalWasteCollectApp
{
    public class TruckTxts
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
