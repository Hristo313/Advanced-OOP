using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParentheses
{
	class Program
	{
		static void Main(string[] args)
		{
			string input = Console.ReadLine();
			Stack<char> openParentheses = new Stack<char>();

			bool isBalanced = true;

			foreach (var symbol in input)
			{
				if (symbol == '(' || symbol == '[' || symbol == '{')
				{
					openParentheses.Push(symbol);
				}
				else
				{
					if (!openParentheses.Any())
					{
						isBalanced = false;
						break;
					}

					char currentOpenParantheses = openParentheses.Pop();

					bool isRoundBalanced = currentOpenParantheses == '(' && symbol == ')';
					bool isSquareBalanced = currentOpenParantheses == '[' && symbol == ']';
					bool isCurlyBalanced = currentOpenParantheses == '{' && symbol == '}';

					if (isRoundBalanced == false && isSquareBalanced == false && isCurlyBalanced == false)
					{
						isBalanced = false;
						break;
					}
				}
			}

			if (isBalanced)
			{
				Console.WriteLine("YES");
			}
			else
			{
				Console.WriteLine("NO");
			}
		}
	}
}
