// liczby całkowite

int myAge = 40;
int newAge = myAge + 5;
Console.WriteLine(newAge);
int myVar = int.MinValue;
uint myVar2 =  uint.MaxValue;
ulong myVar3 = ulong.MaxValue;

// liczby zmienno-przecinkowe
float myNumber = float.MinValue;
double myNumber2 = double.MaxValue;

// zmienne tekstowe
string name = "Marek";
string surname = "7";
string result = name + surname + myAge;
Console.WriteLine(result);
char myVar5 = 'a';
var result2 = name.ToArray();

//zmienna logiczna
bool isActive = true;
isActive = false;
var isValid = 5 > 6;
Console.WriteLine(!isValid);

