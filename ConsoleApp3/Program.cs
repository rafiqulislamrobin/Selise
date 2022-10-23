using System;

public static class Program
{

    public static void Main()
    {
        var input = Console.ReadLine()!.Split(",").ToList();

        var output = FindAnagram(input);

        for (int i = 0; i < output.Count; i++)
        {
            for (int j = 0; j < output[i].Count; j++)
            {
                if (output[i].Count > 1)
                    Console.Write($"{output[i][j]}");

                if (j + 1 != output[i].Count)
                    Console.Write(", ");
            }

            Console.WriteLine();
        }
    }

    public static List<List<string>> FindAnagram(List<string> input)
    {

        List<List<string>> list = new List<List<string>>();

        for (int i = 0; i < input.Count; i++)
        {
            List<string> childList = new List<string>();

            for (int j = i + 1; j < input.Count; j++)
            {
                if (CheckAnagram(input[i].Trim(), input[j].Trim()))
                {
                    childList.Add(input[j].Trim());
                    input.RemoveAt(j);
                    j--;
                }
                if (j + 1 == input.Count)
                {
                    childList.Add(input[i]);
                }
            }

            if (childList.Count > 1)
                list.Add(childList);
        }

        return list;
    }

    public static bool CheckAnagram(string input1, string input2)
    {
        string result1 = string.Concat(input1.ToLower().OrderBy(c => c));
        string result2 = string.Concat(input2.ToLower().OrderBy(c => c));

        if (result1 == result2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}