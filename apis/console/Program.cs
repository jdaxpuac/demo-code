// See https://aka.ms/new-console-template for more information

using console;

string opt;
Console.WriteLine("------------------------------------------------------------");
Console.WriteLine("select task");
Console.WriteLine("1 - calculator");
Console.WriteLine("2 - bank challange");
Console.WriteLine("3 - age calculator");
opt = Console.ReadLine();
switch (opt)
{
    case "1": Calculator calc = new Calculator(); break;
    case "2": Operations ops = new Operations();  break;
    case "3": AgeCalc age = new AgeCalc(); break;
    default : Console.WriteLine("select a valid option"); break;
}




