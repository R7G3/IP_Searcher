using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.IO;

namespace IP_Searcher
{
	public class Program
	{
		public static void Main(string[] args)
		{
			string inFile = "input.txt";
			string outFile="output.txt";
			if (File.Exists(inFile) == true)
			{
				FileStream input = new FileStream(inFile, FileMode.Open);
				StreamReader reader = new StreamReader(input);
				Regex regex = new Regex(@"[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}");
				MatchCollection matches = regex.Matches(reader.ReadToEnd());
				Dictionary<string, string> IPs = new Dictionary<string, string>();
				if (matches.Count > 0)
				{
					int i=0;
					foreach (Match match in matches)
					{
						if (!IPs.ContainsKey(match.Value))
						{
							IPs.Add(match.Value, "");
							i++;
						}
					}
					Console.WriteLine("Найдено {0} IP-адресов.", i);
					File.Create("output.txt").Close();
					foreach (string IP in IPs.Keys)
					{
						File.AppendAllText(outFile, IP+"\r\n");
					}
					Console.WriteLine("Файл output.txt записан.");
				}
				else
				{
					Console.WriteLine("IP не найдены.");
				}
			}
			else
			{
				Console.WriteLine("Файл \"input.txt\" не найден.");
			}
			Console.WriteLine("\nНажмите кнопку, чтобы закрыть.");
			Console.ReadKey();
		}
	}
}