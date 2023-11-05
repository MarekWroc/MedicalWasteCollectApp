using MedicalWasteCollectApp;

var truck = new Truck("SK793FF");
var company = Truck.CompanyName;


Console.WriteLine("===========================");
Console.WriteLine($"Dostępny pojazd firmy {company}:");
Console.WriteLine("---------------------------");

Console.WriteLine($"Pojazd: {truck.RegNumber}, ładowność: {truck.MaxLoad}");


Console.WriteLine("----------------------------");
Console.WriteLine("");

while (true)
{
    Console.WriteLine("Co zamierzasz zrobić?");
    Console.WriteLine("");
    Console.WriteLine("1 - Załadunek");
    Console.WriteLine("2 - Rozładunek");
    Console.WriteLine("3 - Dostępna ładowność");
    Console.WriteLine("4 - Całkowita ładowność");
    Console.WriteLine("Q - Wyjście");
    Console.Write("Więc? :");

    var userInput = Console.ReadLine();

    if (userInput == "q" || userInput == "Q")
    {
        Console.WriteLine("Kończymy na dziś.");
        break;
    }

    switch (userInput)
    {
        case "1":
            Console.WriteLine("Jesteś w załadunek.");
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
            Console.WriteLine("Jesteś w rozładunek.");
            Console.Write("Potwierdź rozładunek wprowadzając dowolną wartość i/lub naciśnij ENTER (powrót do wczesniejszego menu bez rozładunku - q):");
            var unload = Console.ReadLine();
            if (unload != "q" || unload != "Q")
            {
                truck.UnloadWaste();
                Console.WriteLine($"Pojazd rozładowany.");
            } 
            break;
        case "3":
            Console.WriteLine($"Twoja dostępna ładowność to {(truck.MaxLoad - truck.LoadsSum)}kg.");
            break;
        case "4":
            Console.WriteLine($"Twoja całkowita ładowność to {truck.MaxLoad}kg.");
            break;
        default: 
            throw new Exception("Błędna wartość. Wprowadź ponownie lub zakończ (q):");
            break;
    }
}




//truck1.AddWaste(500);
//truck1.AddWaste(0);
//truck1.AddWaste(480);
//truck1.AddWaste(17);
//truck1.AddWaste(12);
////truck1.UnloadWaste();

//truck2.AddWaste(60);
//truck2.AddWaste(25);
//truck2.AddWaste(27);

//truck3.AddWaste(43);
//truck3.AddWaste(12);
//truck3.AddWaste(2);

//truck4.AddWaste(6);
//truck4.AddWaste(68);
//truck4.AddWaste(26);

//var loadsSum1 = truck1.LoadsSum;
////var loadsSum2 = truck2.LoadsSum;
////var loadsSum3 = truck3.LoadsSum;
////var loadsSum4 = truck4.LoadsSum;

//Console.WriteLine(loadsSum1);
////Console.WriteLine(loadsSum2);
////Console.WriteLine(loadsSum3);
////Console.WriteLine(loadsSum4);

//var statistic1 = truck1.GetStatistics();

//Console.WriteLine(truck1.MaxLoad);
//Console.WriteLine(truck1.MaxLoads);
//Console.WriteLine(statistic1.FillingAsLetter);
