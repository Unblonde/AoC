
using System.Collections.Generic;
using System.Text;

class help
{
    public static string[] BreakInputOnLine(string[] input, bool addSpace = false)
    {
        StringBuilder currentLine = new StringBuilder();
        List<string> outString = new List<string>();
        foreach (string line in input)
        {
            if (line.Length == 0 && currentLine.Length > 0)
            {
                outString.Add(currentLine.ToString());
                currentLine.Remove(0, currentLine.Length);
            }
            else
            {
                if(addSpace) currentLine.Append(" ");
                currentLine.Append(line);
                if(addSpace) currentLine.Append(" ");
            }
        }
        if(currentLine.Length != 0) outString.Add(currentLine.ToString());
        return outString.ToArray();
    }

     public static List<System.Tuple<string, int>> BreakInputOnLineWithCount(string[] input, bool addSpace = false)
    {
        StringBuilder currentLine = new StringBuilder();
        List<System.Tuple<string,int>> outString = new List<System.Tuple<string,int>>();
        int count = 0;
        foreach (string line in input)
        {
            if (line.Length == 0 && currentLine.Length > 0)
            {
                
                outString.Add(System.Tuple.Create(currentLine.ToString(), count));
                currentLine.Remove(0, currentLine.Length);
                count = 0;
            }
            else
            {
                if(addSpace) currentLine.Append(" ");
                currentLine.Append(line);
                if(addSpace) currentLine.Append(" ");
                count++;
            }
        }
        if(currentLine.Length != 0) outString.Add(System.Tuple.Create(currentLine.ToString(), count));
        return (outString);
    }
}