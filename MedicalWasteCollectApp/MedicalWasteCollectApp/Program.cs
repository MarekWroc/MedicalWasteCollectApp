using MedicalWasteCollectApp;

var truck = new Truck("SK793FF");
var company = Truck.CompanyName;


Console.WriteLine("===========================");
Console.WriteLine($"Dostępny pojazd firmy {company}:");
Console.WriteLine("---------------------------");

Console.WriteLine($"Pojazd: {truck.RegNumber}, ładowność: {truck.MaxLoad}");


Console.WriteLine("----------------------------");
Console.WriteLine("");

Console.WriteLine("Co zamierzasz zrobić?");
Console.WriteLine("");
Console.WriteLine("1 - Załadunek");
Console.WriteLine("2 - Rozładunek");
Console.WriteLine("3 - Dostępna ładowność");
Console.WriteLine("4 - Całkowita ładowność");
Console.WriteLine("Q - Wyjście");
Console.Write("Więc? :");

while (true)
{
    var userInput = Console.ReadLine();

    if (userInput == "q" || userInput == "Q")
    {
        break;
    }
    
    switch (userInput)
    {
        case "1":
            while (true)
            {
                break;
            }
            break;
        case "2":
            while (true)
            {
                break;
            }
            break;
        case "3":
            while (true)
            {
                break;
            }
            break;
        case "4":
            while (true)
            {
                break;
            }
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
