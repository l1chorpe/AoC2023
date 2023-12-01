namespace AoC1;

class MainClass
{
    public static void Main()
    {
        string[] data = File.ReadAllText("data.txt").Split('\n');
        StripLetters(ref data);
        Console.WriteLine(CalculateSum(data));
    }

    private static void StripLetters(ref string[] data)
    {
        // Loop through all "words"
        for(int i  = 0; i < data.Length; ++i)
        {
            // Iterate from front and back until a number is found
            string number = "";
            for(int j = 0; j < data[i].Length; ++j)
            {
                if (char.IsDigit(data[i][j]))
                {
                    number += data[i][j];
                    break;
                }
            }
            for(int j = data[i].Length -1; j >= 0; --j)
            {
                if (char.IsDigit(data[i][j]))
                {
                    number += data[i][j];
                    break;
                }
            }
            data[i] = number;
        }
    }

    private static int CalculateSum(in string[] numbers)
    {
        int sum = 0;
        foreach(string number in numbers)
        {
            sum += int.Parse(number);
        }
        return sum;
    }
}
