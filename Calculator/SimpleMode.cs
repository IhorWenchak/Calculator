using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;

namespace Calculator
{

	public class SimpleMode
	{
		private string _enteredString = String.Empty;		
		private readonly char[] _startOperations = new char[] { '+', '-' };
		private readonly char[] _priorityOperations = new char[] { '*', '/', '%', ':' };
		private static readonly char[] _allOperations = new char[] { '*', '/', '%', '+', '-', ':' };
		
		public SimpleMode(string enteredString)
		{
			_enteredString = enteredString;
		}
	
		public double GetResult()
		{
			int counter = 0;

			string[] devidedInput = _enteredString.Split(_startOperations);

			double total = GetPriorityValue(devidedInput[counter]);

			IEnumerable<char> operations =  _enteredString.Where(symbol => _startOperations.Contains(symbol));

			foreach (char symbol in operations)
			{
				counter++;
				double addition = GetPriorityValue(devidedInput[counter]);
				total = (symbol == '+') ? (total + addition) : (total - addition);
			}
			return total;
		}

		public double GetPriorityValue(string divided)
		{
			int counter = 0;

			string[] listNumbers = divided.Split(_priorityOperations);

			double.TryParse(listNumbers[counter], out double number);

			double thisTotal = number;

			if (listNumbers.Length == 1)
			{
				return thisTotal;
			}

			IEnumerable<char> operations = divided.Where(symbol => _priorityOperations.Contains(symbol));

			foreach (char operand in operations)
				{
					counter++;

					double.TryParse(listNumbers[counter], out number);

					switch (operand)
					{
						case '*':
							thisTotal *= number;
							break;
						case '/':
							thisTotal /= number;
							break;
						case ':':
							thisTotal /= number;
							break;
						case '%':
							thisTotal %=  number;
							break;
					}
				}

			return thisTotal;
		}


		public static string IsCorrectlyInput(string inputRow)
		{
			int counter = 0;

			string[] digitalsList = inputRow.Split(_allOperations);

			IEnumerable<char> operations = inputRow.Where(symbol => _allOperations.Contains(symbol));

			if (String.IsNullOrEmpty(inputRow))
			
				return "This data is empty.";
			
			else if (inputRow.Contains('(') | inputRow.Contains(')'))
			
				return "Without brackets !";			
			
			foreach (string digital in digitalsList)
			{
				if (!double.TryParse(digital, NumberStyles.Number, CultureInfo.CurrentCulture, out double number))
					
						return String.Format("Сan't digitize: {0} number decimal separator is {1} ", digital, CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
			}

			foreach (char symbol in operations)
			{
				counter++;

				if (((symbol == '/') || (symbol == ':') || (symbol == '%')) && (double.TryParse(digitalsList[counter], out double number)) && (number == 0))
		
					return "It is forbidden to divide by zero !";
			}

			return String.Empty;
		}

	}
}	

