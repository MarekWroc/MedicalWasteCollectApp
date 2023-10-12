Truck truck1 = new Truck("SK9453V");
Truck truck2 = new Truck("SK256HT");
Truck truck3 = new Truck("SK269HT");
Truck truck4 = new Truck("SD53722");

truck1.AddWaste(15);
var loadsSum = truck1.LoadsSum;

class Truck
{
    private List<int> loads = new List<int>();

    public Truck(string regNumber)
    {
        this.RegNumber = regNumber;
    }

    public string RegNumber { get; private set; }

    public int LoadsSum
    {
        get
        {
            return this.loads.Sum();
        }
    }

    public void AddWaste(int load)
    {
        this.loads.Add(load);
    }
}
