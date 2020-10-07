using System;

namespace Calculator
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(" 1 - User input in the console of simple operations (without brackets).");
			Console.WriteLine(" 2 - Reading from a file line by line expressions (to implement the calculation of expressions with brackets):");
			Console.WriteLine();
			Console.Write(" Select the calculator operating mode: ");

			string alegereMode = Console.ReadLine();

			if (int.TryParse(alegereMode, out int valMode))
			{
				switch (valMode)
				{
					case 1:

						string inputLine = String.Empty;

						string outputLine = String.Empty;

						do
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine(String.Format("{0}\n", outputLine));
							Console.ForegroundColor = ConsoleColor.White;
							Console.Write("Enter numbers and simple operations (without brackets !). Try now: ");
							inputLine = Console.ReadLine();
							outputLine = SimpleMode.IsCorrectlyInput(inputLine);
						} while (outputLine != String.Empty);

						SimpleMode simple = new SimpleMode(inputLine);
						
						Console.ForegroundColor = ConsoleColor.Cyan;
						Console.WriteLine(String.Format("Your result: {0}", simple.GetResult()));

						break;

					case 2:
						Console.WriteLine("Reading from a file line by line expressions (to implement the calculation of expressions with brackets)");
						break;
					
					default:
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("This mode does not exist.");
						break;
				}
			}

			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Not a valid symbol.");
			}
			Console.ReadKey();
		}
	}
}
