using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day_5
{
    class Program
    {
        static void Main(string[] args)
        {


            //Import file  
            const bool useExample = false;
            const int day = 7;
            string inFile = @"inputfiles/d" + day.ToString() + ((useExample) ? "Example.in" : "Real.in");
            
            string[] lines = System.IO.File.ReadAllLines(inFile);
            string[] allColours = lines.Select(p => p.Split(" contain ")[0].Replace(" bags", "")).ToArray();

            List<KeyValuePair<string, string>> canContain = new List<KeyValuePair<string, string>>();

            foreach (string colour in allColours)
            {
                foreach (string line in lines)
                {
                    string[] bothParts = line.Split(" contain ");
                    if (bothParts[1].Contains(colour)) canContain.Add(new KeyValuePair<string, string>(colour.Replace(" bags", ""), bothParts[0].Replace(" bags", "")));
                }
            }

            // canContain is List(KVP) of key colour, value containing colour
            int answer = 0;
            HashSet<string> valid = new HashSet<string>();
            //Part 1
            answer = ExtractColours(canContain, "shiny gold", valid).Count;

            //Output answer
            Console.WriteLine("Part 1 Answer: " + Convert.ToString(answer));


            //Part2
            answer = 0;
            List<Tuple<string, string, int>> containsList = new List<Tuple<string, string, int>>();
            foreach (string line in lines)
            {

                string[] outPut = line.Replace(" bags", "").Replace(" bag", "").Replace(".", "").Split(" contain ");
                string key = outPut[0].Replace(" bags", "");
                string[] outPutColours = outPut[1].Split(", ");
                foreach (string opLine in outPutColours)
                {
                    if (opLine.IndexOf("no other") > -1) continue;
                    Tuple<string, string, int> opTuple = new Tuple<string, string, int>(key, opLine.Substring(opLine.IndexOf(" ") + 1), int.Parse(opLine.Substring(0, opLine.IndexOf(" "))));
                    containsList.Add(opTuple);
                }

            }
            answer = CountRecursive(containsList, "shiny gold");
            //Output answer
            Console.WriteLine("Part 2 Answer: " + Convert.ToString(answer));




        }

        public static HashSet<string> ExtractColours(List<KeyValuePair<string, string>> input, string value, HashSet<string> existing)
        {
            bool newOne = true;
            foreach (KeyValuePair<string, string> colourIn in input.Where(p => p.Key == value))
            {
                if (existing.Add(colourIn.Value) == false) newOne = false;
                else existing = ExtractColours(input, colourIn.Value, existing);
            }
            return existing;
        }

        public static int CountRecursive(List<Tuple<string, string, int>> input, string value)
        {
            int total = 0;

            foreach (Tuple<string, string, int> colourIn in input.Where(p => p.Item1 == value))
            {
                total += colourIn.Item3;
                total += CountRecursive(input, colourIn.Item2) * colourIn.Item3;

            }
            return total;
        }


    }
}




