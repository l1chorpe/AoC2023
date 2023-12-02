namespace AoC1;

public class MainClass
{
    private class IndexValuePair {
        public int Index { get; }
        public int Value { get; }

        public IndexValuePair(int index, int value) { Index = index; Value = value; }
    }

    private static readonly string[] str_digits =
    {
        "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
    };

    private static readonly char[] digits = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    public static void Main()
    {
        
        string[] data = File.ReadAllText("data.txt").Split('\n');
        int[] result = StripToNumbers(data);
        Console.WriteLine(CalculateSum(result));
    }

    /// <summary>
    /// Converts each line of data into a list of numbers.
    /// </summary>
    private static int[] StripToNumbers(string[] data)
    {
        int[] numbers = new int[data.Length];

        for(int i  = 0; i < data.Length; ++i)
        {
            int number;
            
            var word = FindFirstDigitWord(data[i]);
            var digit = FindFirstDigit(data[i]);
            number = word.Index < digit.Index ? word.Value * 10 : digit.Value * 10;

            word = FindLastDigitWord(data[i]);
            digit = FindLastDigit(data[i]);
            number += word.Index > digit.Index ? word.Value : digit.Value;

            numbers[i] = number;
        }

        return numbers;
    }

    /// <summary>
    /// Finds the first occurence of written digits ("one", "two"...) in a given line.
    /// </summary>
    /// <returns>A tuple containing the index of the first letter of the digit and its literal value.</returns>
    private static IndexValuePair FindFirstDigitWord(string line)
    {
        IndexValuePair current_ivp = new(line.Length, 0);
        for(int i = 0; i < str_digits.Length; ++i)
        {
            int index = line.IndexOf(str_digits[i]);
            if(index != -1 && index < current_ivp.Index)
            {
                current_ivp = new(index, i + 1);
            }
        }
        return current_ivp;
    }

    /// <summary>
    /// Finds the last occurence of written digits ("one", "two"...) in a given line.
    /// </summary>
    /// <returns>A tuple containing the index of the last letter of the digit and its literal value.</returns>
    private static IndexValuePair FindLastDigitWord(string line)
    {
        IndexValuePair current_ivp = new(-1, 0);
        for(int i = str_digits.Length - 1; i >= 0; --i)
        {
            int index = line.LastIndexOf(str_digits[i]);
            if(index != -1 && index > current_ivp.Index)
            {
                current_ivp = new(index, i + 1);
            }
        }
        return current_ivp;
    }

    /// <summary>
    /// Finds the first occurence of any digit in a given line.
    /// </summary>
    /// <returns>A tuple containing the digit's index and literal value.</returns>
    private static IndexValuePair FindFirstDigit(string line)
    {
        IndexValuePair current_ivp = new(line.Length, 0);
        for (int i = 0; i < digits.Length; ++i)
        {
            int index = line.IndexOf(digits[i]);
            if (index != -1 && index < current_ivp.Index)
            {
                current_ivp = new(index, i + 1);
            }
        }
        return current_ivp;
    }

    /// <summary>
    /// Finds the last occurence of any digit in a given line.
    /// </summary>
    /// <returns>A tuple containing the digit's index and literal value.</returns>
    private static IndexValuePair FindLastDigit(string line)
    {
        IndexValuePair current_ivp = new(-1, 0);
        for (int i = digits.Length - 1; i >= 0; --i)
        {
            int index = line.LastIndexOf(digits[i]);
            if (index != -1 && index > current_ivp.Index)
            {
                current_ivp = new(index, i + 1);
            }
        }
        return current_ivp;
    }

    private static int CalculateSum(in int[] numbers)
    {
        int sum = 0;
        foreach(int number in numbers)
            sum += number;
        return sum;
    }
}
