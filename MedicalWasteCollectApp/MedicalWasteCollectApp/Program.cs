List<int> loads = new List<int>();
loads.Add(76);
loads.Add(37);
loads.Add(13);
loads.Add(54);
loads.Add(32);

for (var i = 0; i < loads.Count; i++)
{
    Console.WriteLine(loads[i]);
}

var loadsSum = 0;

foreach (var load in loads)
{
    Console.WriteLine(load);

    loadsSum = loadsSum + load;
}

Console.WriteLine(loadsSum);

string loadsAsString = loadsSum.ToString();
char[] letters = loadsAsString.ToArray();

int[] counter = new int[10];
foreach (char letter in letters)
{
    if (letter == '0')
    {
        counter[0]++;
    } 
    else if (letter == '1')
    {
        counter[1]++;
    }
    else if (letter == '2')
    {
        counter[2]++;
    }
    else if (letter == '3')
    {
        counter[3]++;
    }
    else if (letter == '4')
    {
        counter[4]++;
    }
    else if (letter == '5')
    {
        counter[5]++;
    }
    else if (letter == '6')
    {
        counter[6]++;
    }
    else if (letter == '7')
    {
        counter[7]++;
    }
    else if (letter == '8')
    {
        counter[8]++;
    }
    else if (letter == '9')
    {
        counter[9]++;
    }
}
for(var i=0; i<counter.Length; i++)
{
    Console.WriteLine(i+" => " + counter[i]);
}
