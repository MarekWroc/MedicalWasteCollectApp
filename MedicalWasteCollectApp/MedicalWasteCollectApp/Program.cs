using MedicalWasteCollectApp;

while (true)
{
    Console.Write("Wybierz wersję 1 - praca na pamięci, lub 2 - praca na plikach (q - wyjście): ");
    var versionSelection = Console.ReadLine();

    if (versionSelection == "q" || versionSelection == "Q")
    {
        TruckTxts.PrintWelcome();
        break;
    }

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
                TruckTxts.MainMenu();

                var userInput = Console.ReadLine();


                if (userInput == "q" || userInput == "Q")
                {
                    break;
                }

                switch (userInput)
                {
                    case "1":
                        TruckTxts.InLoad();

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
                        TruckTxts.ConfirmUnload();

                        var unload = Console.ReadLine();
                        if (unload != "q" || unload != "Q")
                        {
                            if (truck_mem.LoadsSum > 0)
                            {
                                truck_mem.UnloadWaste();

                                TruckTxts.UnloadConfirmation();
                            }
                            else
                            {
                                TruckTxts.CantUnload();
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
                        Console.WriteLine("Błędna wartość. Wprowadź ponownie lub powrót (q):");
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
                TruckTxts.MainMenu();

                var userInput = Console.ReadLine();

                if (userInput == "q" || userInput == "Q")
                {
                    break;
                }

                switch (userInput)
                {
                    case "1":
                        TruckTxts.InLoad();

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
                        TruckTxts.ConfirmUnload();

                        var unload = Console.ReadLine();
                        if (unload != "q" || unload != "Q")
                        {
                            if (truck.LoadsSum > 0)
                            {
                                truck.UnloadWaste();

                                TruckTxts.UnloadConfirmation();
                            }
                            else
                            {
                                TruckTxts.CantUnload();
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
                        Console.WriteLine("Błędna wartość. Wprowadź ponownie lub powrót (q):");
                        break;
                }
            }
            break;
        default:
            Console.WriteLine("Wprowadzona błędna wartość.");
            break;
    }
}