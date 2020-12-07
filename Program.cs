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

            //build graph
            List<Tuple<string, string, int>> containsList = new List<Tuple<string, string, int>>();
            foreach (string line in lines)
            {
                string[] outPut = line.Replace(" bags", "").Replace(" bag", "").Replace(".", "").Split(" contain ");
                string[] outPutColours = outPut[1].Split(", ");
                foreach (string opLine in outPutColours)
                {
                    if (opLine.IndexOf("no other") > -1) continue;
                    Tuple<string, string, int> opTuple = new Tuple<string, string, int>(outPut[0], opLine.Substring(opLine.IndexOf(" ") + 1), int.Parse(opLine.Substring(0, opLine.IndexOf(" "))));
                    containsList.Add(opTuple);
                }
            }

            //Part 1
            int answer = 0;
            answer = CountPossibilities(containsList, "shiny gold").Count;
            //Output answer
            Console.WriteLine("Part 1 Answer: " + Convert.ToString(answer));


            //Part2
            answer = 0;
            answer = CountRecursive(containsList, "shiny gold");
            //Output answer
            Console.WriteLine("Part 2 Answer: " + Convert.ToString(answer));

        }

        public static HashSet<string> CountPossibilities(List<Tuple<string, string, int>> input, string value, HashSet<string> existingColours = null)
        {
            if (existingColours is null) existingColours = new HashSet<string>();
            foreach (Tuple<string, string,int> colourIn in input.Where(p => p.Item2 == value))
            {
                if (existingColours.Add(colourIn.Item1) == true) existingColours = CountPossibilities(input, colourIn.Item1, existingColours);
             }
            return existingColours;
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





