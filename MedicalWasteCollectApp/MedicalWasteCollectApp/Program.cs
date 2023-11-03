using MedicalWasteCollectApp;

Truck truck1 = new Truck("SK9453V");
//Truck truck2 = new Truck("SK256HT");
//Truck truck3 = new Truck("SK269HT");
//Truck truck4 = new Truck("SD53722");

//var company = Truck.CompanyName;

truck1.AddWaste(500);
truck1.AddWaste(7);
////truck1.AddWaste(12);
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

var loadsSum1 = truck1.LoadsSum;
////var loadsSum2 = truck2.LoadsSum;
////var loadsSum3 = truck3.LoadsSum;
////var loadsSum4 = truck4.LoadsSum;

Console.WriteLine(loadsSum1);
////Console.WriteLine(loadsSum2);
////Console.WriteLine(loadsSum3);
////Console.WriteLine(loadsSum4);

var statistic1 = truck1.GetStatistics();

Console.WriteLine(truck1.MaxLoad);
//Console.WriteLine(truck1.MaxLoads);
Console.WriteLine(statistic1.FillingAsLetter);
