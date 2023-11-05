using MedicalWasteCollectApp;

Console.Write("Wybierz wersję 1 - praca na pamięci, lub 2 - praca na plikach: ");
var versionSelection = Console.ReadLine();

switch (versionSelection)
{
    case "1":
        var truck_mem = new TruckInMemory("WDBA901A906894402", "SK793FF");
        var company_mem = TruckInMemory.CompanyName;
        var depot_mem = TruckInMemory.Depot;
        truck_mem.WasteAdded += TruckWasteAdded;

        void TruckWasteAdded(object sender, EventArgs args)
        {
            Console.WriteLine("Odpady załadowane.");
        }

        Console.WriteLine("================================");
        Console.WriteLine($"Dostępny pojazd firmy {company_mem}, o/ {depot_mem}:");
        Console.WriteLine("--------------------------------");

        Console.WriteLine($"Pojazd: {truck_mem.RegNumber}, ładowność: {truck_mem.MaxLoad}");


        Console.WriteLine("--------------------------------");
        Console.WriteLine("");

        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("Co zamierzasz zrobić?");
            Console.WriteLine("");
            Console.WriteLine("1 - Załadunek");
            Console.WriteLine("2 - Rozładunek");
            Console.WriteLine("3 - Wyświetla statystyki");
            Console.WriteLine("Q - Wyjście");
            Console.Write("Więc? :");

            var userInput = Console.ReadLine();

            if (userInput == "q" || userInput == "Q")
            {
                Console.WriteLine("");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("         Kończymy na dziś.          ");
                Console.WriteLine("------------------------------------");
                break;
            }

            switch (userInput)
            {
                case "1":
                    Console.WriteLine("");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Jesteś w załadunek.");
                    Console.WriteLine("");
                    while (true)
                    {
                        Console.Write("Ile odpadów zabieramy? Podaj masę (powrót do wczesniejszego menu - q):");
                        var load = Console.ReadLine();
                        if (load == "q" || load == "Q")
                        {
                            break;
                        }

                        try
                        {
                            truck_mem.AddWaste(load);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Błąd: {ex.Message}");
                        }
                    }
                    break;
                case "2":
                    Console.WriteLine("");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Jesteś w rozładunek.");
                    Console.Write("Potwierdź rozładunek wprowadzając dowolną wartość i/lub naciśnij ENTER (powrót do wczesniejszego menu bez rozładunku - q):");
                    var unload = Console.ReadLine();
                    if (unload != "q" || unload != "Q")
                    {
                        if (truck_mem.LoadsSum > 0)
                        {
                            truck_mem.UnloadWaste();
                            Console.WriteLine("");
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine($"Pojazd rozładowany.");
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Pojazd jest pusty, nie ma nic do rozładowania.");
                        }
                    }
                    break;
                case "3":
                    var statistics = truck_mem.GetStatistics();

                    Console.WriteLine("");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Statystyki:");
                    Console.WriteLine("");
                    Console.WriteLine($"Minimalna masa odebranego odpadu to {statistics.Min}.");
                    Console.WriteLine($"Maksymalna masa odebranego odpadu to {statistics.Max}.");
                    Console.WriteLine($"Średnia masa odebranego odpadu to {statistics.Average:0}");
                    Console.WriteLine($"Twoja dostępna ładowność to {(truck_mem.MaxLoad - truck_mem.LoadsSum)}kg.");
                    Console.WriteLine($"Poziom załadowania to {statistics.FillingAsLetter}, (A wysoki, E niski).");
                    Console.WriteLine($"Twoja całkowita ładowność to {truck_mem.MaxLoad}kg.");
                    Console.WriteLine("");
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Błędna wartość. Wprowadź ponownie lub zakończ (q):");
                    break;
            }
        }
        break;
    case "2":
        var truck = new TruckInFile("WDBA901A906894402", "SK793FF");
        var company = TruckInFile.CompanyName;
        var depot = TruckInFile.Depot;
    
        Console.WriteLine("================================");
        Console.WriteLine($"Dostępny pojazd firmy {company}, o/ {depot}:");
        Console.WriteLine("--------------------------------");

        Console.WriteLine($"Pojazd: {truck.RegNumber}, ładowność: {truck.MaxLoad}");


        Console.WriteLine("--------------------------------");
        Console.WriteLine("");

        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("Co zamierzasz zrobić?");
            Console.WriteLine("");
            Console.WriteLine("1 - Załadunek");
            Console.WriteLine("2 - Rozładunek");
            Console.WriteLine("3 - Wyświetla statystyki");
            Console.WriteLine("Q - Wyjście");
            Console.Write("Więc? :");

            var userInput = Console.ReadLine();

            if (userInput == "q" || userInput == "Q")
            {
                Console.WriteLine("");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("         Kończymy na dziś.          ");
                Console.WriteLine("------------------------------------");
                break;
            }

            switch (userInput)
            {
                case "1":
                    Console.WriteLine("");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Jesteś w załadunek.");
                    Console.WriteLine("");
                    while (true)
                    {
                        Console.Write("Ile odpadów zabieramy? Podaj masę (powrót do wczesniejszego menu - q):");
                        var load = Console.ReadLine();
                        if (load == "q" || load == "Q")
                        {
                            break;
                        }

                        try
                        {
                            truck.AddWaste(load);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Błąd: {ex.Message}");
                        }
                    }
                    break;
                case "2":
                    Console.WriteLine("");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Jesteś w rozładunek.");
                    Console.Write("Potwierdź rozładunek wprowadzając dowolną wartość i/lub naciśnij ENTER (powrót do wczesniejszego menu bez rozładunku - q):");
                    var unload = Console.ReadLine();
                    if (unload != "q" || unload != "Q")
                    {
                        if (truck.LoadsSum > 0)
                        {
                            truck.UnloadWaste();
                            Console.WriteLine("");
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine($"Pojazd rozładowany.");
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("------------------------------------");
                            Console.WriteLine("Pojazd jest pusty, nie ma nic do rozładowania.");
                        }
                    }
                    break;
                case "3":
                    var statistics = truck.GetStatistics();

                    Console.WriteLine("");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Statystyki:");
                    Console.WriteLine("");
                    Console.WriteLine($"Minimalna masa odebranego odpadu to {statistics.Min}.");
                    Console.WriteLine($"Maksymalna masa odebranego odpadu to {statistics.Max}.");
                    Console.WriteLine($"Średnia masa odebranego odpadu to {statistics.Average:0}");
                    Console.WriteLine($"Twoja dostępna ładowność to {(truck.MaxLoad - truck.LoadsSum)}kg.");
                    Console.WriteLine($"Poziom załadowania to {statistics.FillingAsLetter}, (A wysoki, E niski).");
                    Console.WriteLine($"Twoja całkowita ładowność to {truck.MaxLoad}kg.");
                    Console.WriteLine("");
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Błędna wartość. Wprowadź ponownie lub zakończ (q):");
                    break;
            }
        }
        break;
    default: 
        Console.WriteLine("Wprowadzona błędna wartość.");
        break;
}

