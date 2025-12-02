using AdventOfCode;

var day = new Day2();
Console.WriteLine(day.SolveB());

//Console.WriteLine("Enter the day you want to run:");

//var dayInput = Console.ReadLine();
//int day;
//while (!int.TryParse(dayInput, out day))
//{
//    dayInput = Console.ReadLine();
//    Console.WriteLine("That's not a number, enter the day you want to run:");
//}

//Console.WriteLine("Enter the part you want to run (A or B):");

//var part = Console.ReadLine();
//while (!string.Equals(part, "A", StringComparison.InvariantCultureIgnoreCase) && !string.Equals(part, "B", StringComparison.InvariantCultureIgnoreCase))
//{
//    Console.WriteLine("Try again. Enter the part you want to run (A or B):");
//    part = Console.ReadLine();

//}



//var @class = Type.GetType($"Day{day}.cs");
//if (@class == null) { Console.WriteLine("Oops, you don't seem to have written that day yet"); return; }

//if (string.Equals(part, "A", StringComparison.InvariantCultureIgnoreCase))
//{
//    Console.WriteLine(((IDay)@class).SolveA());
//}
//else
//{
//    Console.WriteLine(((IDay)@class).SolveB());
//}