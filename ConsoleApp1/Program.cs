// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");

TestDiv div = new Calculator();
Calculator calculator = new Calculator();

CalcDelegate<double> calc = new CalcDelegate<double>(div.Div);
calc += calculator.Add;
calc += Calculator.Mult;
calc += Calculator.Sub;
Console.WriteLine(calc(4,1));

foreach (CalcDelegate<double> item in calc.GetInvocationList())
    Console.WriteLine(item(4, 1));

CalcDelegate<int> calc2 = new CalcDelegate<int>(Calculator.Sub);
calc2 += calculator.Add;

List<string> names = new List<string>();
names.Add("Bruce");
names.Add("Alfred");
names.Add("Tim");
names.Add("Richard");

// Display the contents of the list using the Print method.
names.ForEach(Print);

Action<List<string>, bool, int, int, double, Calculator> action = Method;
Func<double, double, double> calc3 = calculator.Add;
calc3 += Calculator.Sub;
calc3 += Calculator.Mult;

foreach(Func<double, double, double> item in calc3.GetInvocationList())
    Console.WriteLine(item(5,4));

//Func<double, double, bool> 
Predicate<double> predicate = MyMethod;
Console.WriteLine(predicate(0));
Check(new List<string>());

bool MyMethod(double d)
{
    return d == 0;
}
void Print(string s)
{
    Console.WriteLine(s + " " + s.GetHashCode());
}

void Method(List<string> s, bool b, int i1, int i2, double d1, Calculator c)
{

}

void Check(List<string> d)
{
    if (!d.Any())
        return;

    Console.WriteLine("check");
}
