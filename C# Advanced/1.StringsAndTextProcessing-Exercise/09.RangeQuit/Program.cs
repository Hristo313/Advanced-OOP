using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace p_09
{
	class Program
	{
		static void Main(string[] args)
		{
			string input = Console.ReadLine();
			List<StringBuilder> listResult = new List<StringBuilder>();
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < input.Length; i++)
			{
				var currIndex = input[i];
				bool isThisEndIndex = i == input.Length - 1;

				if (!char.IsDigit(currIndex))
				{
					sb.Append(currIndex);
				}

				else
				{
					sb.Append(currIndex);

					if (isThisEndIndex == true)
					{
						listResult.Add(sb);
						sb = new StringBuilder();
						break;
					}

					else
					{
						if (char.IsDigit(input[i + 1]))
						{
							continue;
						}

						else
						{
							listResult.Add(sb);
							sb = new StringBuilder();
						}
					}
				}
			}
			List<Item> itemList = new List<Item>();

			for (int i = 0; i < listResult.Count; i++)
			{
				var item = listResult[i];
				string stringResult = "";
				int repeatTime = 0;
				string charTime = " ";

				for (int j = 0; j < item.Length; j++)
				{
					bool isThisEndIndex = j == item.Length - 1;

					if (!char.IsDigit(item[j]))
					{
						stringResult += item[j];
					}

					else
					{
						Item items = new Item();

						if (isThisEndIndex)
						{
							charTime += item[j];
							repeatTime = int.Parse(charTime);

							items.String = stringResult.ToUpper();
							items.RepateTime += repeatTime;
							itemList.Add(items);
						}

						else
						{
							charTime += item[j];
						}
					}
				}
			}
			input = input.ToUpper();
			var ne6tosi = input.Distinct();
			int count = 0;

			foreach (var item in ne6tosi)
			{
				if (!char.IsDigit(item))
				{
					count++;
				}
			}
			StringBuilder builder = new StringBuilder();
			Console.WriteLine($"Unique symbols used: {count}");

			foreach (var kvp in itemList)
			{
				for (int k = 0; k < kvp.RepateTime; k++)
				{
					builder.Append(kvp.String);
				}
			}
			Console.WriteLine(builder);
		}
		class Item
		{
			public string String { get; set; }
			public int RepateTime { get; set; }
		}
	}
}